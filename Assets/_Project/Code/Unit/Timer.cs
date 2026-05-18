using System;
using System.Collections;
using _Project.Code.Spawners;
using UnityEngine;

namespace _Project.Code
{
    public class Timer
    {
        private readonly ICoroutineRunner _coroutineRunner;

        private float _timeWork = 5;
        private float _workCurrentTimeWork;

        public Timer(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }


        public void Start(Action onEndAction = null)
        {
            _coroutineRunner.RunCoroutine(StartCoroutine(onEndAction));
        }

        private IEnumerator StartCoroutine(Action onEndAction = null)
        {
            _workCurrentTimeWork = _timeWork;

            while (_workCurrentTimeWork >= 0)
            {
                _workCurrentTimeWork -= Time.deltaTime;
                
                yield return null;
            }

            onEndAction?.Invoke();
        }
    }
}