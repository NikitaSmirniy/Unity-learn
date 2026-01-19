using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Timer : IValueChangableObserver
{
    private float _currentTimeWork = 0f;
    private float _minRandomTimerTime = 2;
    private float _maxRandomTimerTime = 5;

    private Coroutine _coroutine;
    private ICoroutinesRunner _coroutinesRunner;
    
    public event Action<float> ValueChanged;

    public Timer(TimerConfig timerConfig, ICoroutinesRunner coroutinesRunner)
    {
        _minRandomTimerTime = timerConfig.MinRandomTimerTime;
        _maxRandomTimerTime = timerConfig.MaxRandomTimerTime;
        _coroutinesRunner = coroutinesRunner;
    }

    public void StartTimer(Action action)
    {
        if (_coroutine == null)
            _coroutine = _coroutinesRunner.StartRoutine(TimerRoutine(action));
    }

    private IEnumerator TimerRoutine(Action action)
    {
        var randomTimerTime = Random.Range(_minRandomTimerTime, _maxRandomTimerTime);

        _currentTimeWork = randomTimerTime;

        while (_currentTimeWork >= 0)
        {
            _currentTimeWork -= Time.deltaTime;
            
            ValueChanged?.Invoke(_currentTimeWork /  randomTimerTime);

            yield return null;
        }

        action?.Invoke();

        _coroutine = null;
    }
}