using _Project.Code;
using FSMTest;
using UnityEngine;

public class BaseFactory
{
    private readonly Base _basePrefab;
    private readonly UnitFactory _unitFactory;
    private readonly Flag _flagPrefab;
    private readonly ContainerOccupiedItems _containerOccupiedItems;

    public BaseFactory(Base basePrefab, UnitFactory unitFactory, Flag flagPrefab,
        ContainerOccupiedItems containerOccupiedItems)
    {
        _basePrefab = basePrefab;
        _unitFactory = unitFactory;
        _flagPrefab = flagPrefab;
        _containerOccupiedItems = containerOccupiedItems;
    }

    public Base Create(Vector3 spawnPosition)
    {
        Base newBase = Object.Instantiate(_basePrefab, spawnPosition, Quaternion.identity);

        StateMachine stateMachine = new StateMachine();

        ColonizationBaseState colonizationBaseState = new ColonizationBaseState(stateMachine, newBase);
        IncreasingUnitsState increasingUnitsState = new IncreasingUnitsState(stateMachine, newBase, _unitFactory);

        ToColonizationBaseTransition toColonizationBaseTransition =
            new ToColonizationBaseTransition(colonizationBaseState, newBase);
        ToIncreasingUnitsTransition toIncreasingUnitsTransition =
            new ToIncreasingUnitsTransition(increasingUnitsState, newBase);

        colonizationBaseState.AddTransition(toIncreasingUnitsTransition);

        increasingUnitsState.AddTransition(toColonizationBaseTransition);

        stateMachine.ChangeState(increasingUnitsState);

        Wallet wallet = new Wallet();
        
        Flag newFlag = Object.Instantiate(_flagPrefab, spawnPosition, Quaternion.identity);
        
        newBase.Init(stateMachine, wallet, newFlag, this, _containerOccupiedItems);

        return newBase;
    }
}