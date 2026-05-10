using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Code
{
    public class Base : MonoBehaviour
    {
        private ItemDetector _itemDetector;
        private Queue<Item> _freeItems = new Queue<Item>();
        private List<Unit> _units;
        private int _itemAmount;

        public event Action<int> ItemAmountChanged;
        
        public void Init(ItemDetector itemDetector, List<Unit> units)
        {
            _itemDetector = itemDetector;
            
            _itemDetector.Detected += OnItemDetected;

            _units = new List<Unit>(units);

            SubscribeOnItemDelivered();
        }

        private void OnDisable()
        {
            if (_itemDetector != null)
                _itemDetector.Detected -= OnItemDetected;

            UnsubscribeOnItemDelivered();
        }

        private void Update()
        {
            if (_freeItems.Count != 0 && TryGetFreeUnit(out Unit unit))
            {
                unit.SetTargetItem(_freeItems.Dequeue());
            }
        }

        private bool TryGetFreeUnit(out Unit freeUnit)
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

        private void SubscribeOnItemDelivered()
        {
            foreach (var unit in _units)
                unit.ItemDelivered += OnItemDelivered;
        }

        private void UnsubscribeOnItemDelivered()
        {
            foreach (var unit in _units)
                unit.ItemDelivered -= OnItemDelivered;
        }

        private void OnItemDetected(Item item)
        {
            _freeItems.Enqueue(item);
        }

        private void OnItemDelivered()
        {
            _itemAmount++;
            ItemAmountChanged?.Invoke(_itemAmount);
        }
    }
}