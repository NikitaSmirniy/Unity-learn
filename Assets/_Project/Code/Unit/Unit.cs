using System;
using FSMTest;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Code
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private ItemDetector _itemDetector;
        [SerializeField] private BaseDetector _baseDetector;
        [SerializeField] private Transform _holdingPoint;

        private StateMachine _stateMachine;
        private NavMeshAgent _agent;
        private UnitStateMachineBuilder _unitStateMachineBuilder;

        public event Action ItemDelivered;
        
        public void Init(Transform baseTransform)
        {
            _agent = GetComponent<NavMeshAgent>();

            _unitStateMachineBuilder = new UnitStateMachineBuilder();

            _stateMachine = _unitStateMachineBuilder.Build(this, _agent, baseTransform);
        }

        public Item HoldingItem { get; private set; }
        public Item TargetItem { get; private set; }
        public bool IsBusy => TargetItem;

        private void OnEnable()
        {
            _itemDetector.Detected += OnItemDetected;
            _baseDetector.Detected += OnBaseDetected;
        }

        private void OnDisable()
        {
            _itemDetector.Detected -= OnItemDetected;
            _baseDetector.Detected -= OnBaseDetected;
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        public void SetTargetItem(Item target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            TargetItem = target;
        }

        private void OnBaseDetected()
        {
            if (IsBusy && HoldingItem)
            {
                HoldingItem.Die();
                HoldingItem = null;
                TargetItem = null;
                
                ItemDelivered?.Invoke();
            }
        }

        private void OnItemDetected(Item item)
        {
            if (TargetItem == item && HoldingItem == null)
            {
                HoldingItem = item;
                item.transform.SetParent(_holdingPoint);
                item.transform.localPosition = Vector3.zero;

                item.GetCollected();
            }
        }
    }
}