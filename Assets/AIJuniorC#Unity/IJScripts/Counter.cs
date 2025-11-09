using System;
using System.Collections;
using UnityEngine;

namespace IJuniorScripts
{
    [RequireComponent(typeof(CounterHandler))]
    [RequireComponent(typeof(CounterView))]
    public class Counter : MonoBehaviour
    {
        [SerializeField] private float _delay = 0.5f;
        [SerializeField] private float _addedScore = 1;

        private Coroutine _cashCoroutine;
        private WaitForSeconds _wait;
        private float _currentScore;

        public event Action<float> ScoreChanged;

        public float AddedScore
        {
            get => _addedScore;
            private set
            {
                _addedScore = Mathf.Clamp(value, 0, int.MaxValue);
            }
        }

        public float CurrentScore
        {
            get => _currentScore;
            private set
            {
                _currentScore = Mathf.Clamp(value, 0, int.MaxValue);
                ScoreChanged?.Invoke(_currentScore);
            }
        }

        public bool HasCashCoroutine => _cashCoroutine != null;

        private void Start()
        {
            _wait = new WaitForSeconds(_delay);

            StartCoroutine();
        }

        private IEnumerator IncreasingValueCoroutine()
        {
            while (enabled)
            {
                yield return _wait;

                CurrentScore += _addedScore;
            }
        }

        public void StartCoroutine()
        {
            if (HasCashCoroutine == false)
                _cashCoroutine = StartCoroutine(IncreasingValueCoroutine());
        }

        public void StopCoroutine()
        {
            if (HasCashCoroutine)
            {
                StopCoroutine(_cashCoroutine);
                _cashCoroutine = null;
            }
        }
    }
}