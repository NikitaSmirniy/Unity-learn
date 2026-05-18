using System;
using System.Collections.Generic;
using FSMTest;
using UnityEngine;

namespace _Project.Code
{
    public class Base : MonoBehaviour
    {
        [SerializeField] private ItemDetector _itemDetector;

        private Queue<Item> _freeItems = new Queue<Item>();
        private List<Unit> _units = new List<Unit>();
        private StateMachine _stateMachine;
        private BaseFactory _baseFactory;
        private ContainerOccupiedItems _containerOccupiedItems;

        public bool IsBuildingNewBase { get; private set; }
        public Wallet Wallet { get; private set; }
        public Flag Flag { get; private set; }

        public void Init(StateMachine stateMachine, Wallet wallet, Flag flag,
            BaseFactory baseFactory, ContainerOccupiedItems containerOccupiedItems)
        {
            _containerOccupiedItems = containerOccupiedItems;
            _baseFactory = baseFactory;
            _stateMachine = stateMachine;
            Wallet = wallet;
            Flag = flag;
        }

        private void OnEnable()
        {
            if (_itemDetector != null)
                _itemDetector.Detected += OnItemDetected;
        }

        private void OnDisable()
        {
            if (_itemDetector != null)
                _itemDetector.Detected -= OnItemDetected;

            UnsubscribeOnItemDelivered();
        }

        private void Update()
        {
            _stateMachine.Update();

            if (_freeItems.Count != 0 && TryGetFreeUnit(out Unit unit))
            {
                Item freeItem = _freeItems.Dequeue();

                unit.SetTarget(freeItem);
            }
        }

        public void AddUnit(Unit unit)
        {
            if (unit == null)
                throw new ArgumentNullException("unit");

            _units.Add(unit);

            unit.ItemDelivered += OnItemDelivered;
        }

        public bool TryGetFreeUnit(out Unit freeUnit)
        {
            foreach (var unit in _units)
            {
                if (unit.IsBusy == false)
                {
                    freeUnit = unit;

                    return true;
                }
            }

            freeUnit = null;

            return false;
        }

        public void SetFlagToBuildingNewBase(Vector3 position)
        {
            if (IsBuildingNewBase == false)
            {
                Flag.IsSet = true;
                Flag.transform.position = position;
            }
        }

        public void TryRemoveBuilding()
        {
            if (IsBuildingNewBase == false)
            {
                Flag.IsSet = false;
                Flag.transform.position = transform.position;
            }
        }

        public void OnBuilt(Unit unit)
        {
            Base newBase = _baseFactory.Create(unit.Target.GetPosition());

            newBase.AddUnit(unit);
            unit.SetBaseTransform(newBase.transform);

            unit.Built -= OnBuilt;
            unit.ItemDelivered -= OnItemDelivered;

            _units.Remove(unit);

            Flag.IsSet = false;
            Flag.transform.position = transform.position;

            IsBuildingNewBase = false;
        }

        private void UnsubscribeOnItemDelivered()
        {
            foreach (var unit in _units)
                unit.ItemDelivered -= OnItemDelivered;
        }

        private void OnItemDetected(Item item)
        {
            if (_containerOccupiedItems.TryAddItem(item))
                _freeItems.Enqueue(item);
        }

        private void OnItemDelivered(Item item)
        {
            Wallet.Add(amount: 1);

            _containerOccupiedItems.RemoveItem(item);
        }
    }
}