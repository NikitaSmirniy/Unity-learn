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
        [SerializeField] private FlagDetector _flagDetector;
        [SerializeField] private Transform _holdingPoint;

        private StateMachine _stateMachine;
        private NavMeshAgent _agent;
        private Timer _timer;

        public Transform BaseTransform { get; private set; }
        public Item HoldingItem { get; private set; }
        public ITarget Target { get; private set; }
        public bool IsBuilding { get; private set; }
        public bool IsBusy => Target != null;
        
        public event Action<Item> ItemDelivered;
        public event Action<Unit> Built;

        public void Init(Transform baseTransform, Timer timer, StateMachine stateMachine)
        {
            _agent = GetComponent<NavMeshAgent>();

            _timer = timer;

            BaseTransform = baseTransform;

            _stateMachine = stateMachine;
        }

        private void OnEnable()
        {
            _itemDetector.Detected += OnItemDetected;
            _baseDetector.Detected += OnBaseDetected;
            _flagDetector.Detected += OnFlagDetected;
        }

        private void OnDisable()
        {
            _itemDetector.Detected -= OnItemDetected;
            _baseDetector.Detected -= OnBaseDetected;
            _flagDetector.Detected -= OnFlagDetected;
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        public void SetBaseTransform(Transform baseTransform)
        {
            if (baseTransform == null)
                throw new ArgumentNullException(nameof(baseTransform));

            BaseTransform = baseTransform;
        }

        public void SetTarget(ITarget target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            Target = target;
        }

        public void SetDestination(Vector3 destination)
        {
            _agent.SetDestination(destination);
        }

        public void RemoveTarget()
        {
            Target = null;
        }

        private void OnBaseDetected(Base detectedBase)
        {
            if (BaseTransform == detectedBase.transform)
            {
                if (IsBusy && HoldingItem)
                {
                    ItemDelivered?.Invoke(HoldingItem);

                    HoldingItem.Die();
                    HoldingItem = null;
                    Target = null;
                }
            }
        }

        private void OnItemDetected(Item item)
        {
            if (Target == item && HoldingItem == null)
            {
                HoldingItem = item;
                item.transform.SetParent(_holdingPoint);
                item.transform.localPosition = Vector3.zero;

                item.GetCollected();
            }
        }

        private void OnFlagDetected(Flag flag)
        {
            if (Target == flag && IsBuilding == false)
            {
                IsBuilding = true;

                _timer.Start(EndBuilding);
            }
        }

        private void EndBuilding()
        {
            IsBuilding = false;

            Built?.Invoke(this);
        }
    }
}