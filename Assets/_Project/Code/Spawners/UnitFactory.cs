using _Project.Code;
using _Project.Code.Spawners;
using UnityEngine;

public class UnitFactory
{
    private Unit _prefab;
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly UnitStateMachineBuilder _unitStateMachineBuilder;

    public UnitFactory(Unit prefab, ICoroutineRunner coroutineRunner, UnitStateMachineBuilder unitStateMachineBuilder)
    {
        _prefab = prefab;
        _coroutineRunner = coroutineRunner;
        _unitStateMachineBuilder = unitStateMachineBuilder;
    }

    public Unit Create(Transform baseTransform)
    {
        Unit newUnit = Object.Instantiate(_prefab, new Vector3(baseTransform.position.x, 0, baseTransform.position.z),
            Quaternion.identity);

        Timer timer = new Timer(_coroutineRunner);

        newUnit.Init(baseTransform, timer, _unitStateMachineBuilder.Build(newUnit));

        return newUnit;
    }
}