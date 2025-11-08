using System;
using UnityEngine;

namespace IJuniorScripts
{
    public class CounterHandler : MonoBehaviour
    {
        private Counter _counter;
        private event Func<bool> InputHappend;

        private void Start()
        {
            _counter = GetComponent<Counter>();
            //InputHappend += () => Input.GetMouseButtonDown(0);
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