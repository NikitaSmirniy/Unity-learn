using System;
using UnityEngine;

namespace IJuniorScripts
{
    [RequireComponent(typeof(Counter))]
    public class CounterHandler : MonoBehaviour
    {
        private Counter _counter;

        private void Start()
        {
            _counter = GetComponent<Counter>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                SetState();
        }

        private void SetState()
        {
            if (_counter.HasCashCoroutine == false)
                _counter.StartCoroutine();
            else
                _counter.StopCoroutine();
        }
    }
}