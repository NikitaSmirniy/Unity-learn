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
    private ICorouitinesRunner _corouitinesRunner;

    public event Action<float> ValueChanged;

    public Timer(TimerData timerData, ICorouitinesRunner corouitinesRunner)
    {
        _minRandomTimerTime = timerData.MinRandomTimerTime;
        _maxRandomTimerTime = timerData.MaxRandomTimerTime;
        _corouitinesRunner = corouitinesRunner;
    }

    public void StartTimer(Action action)
    {
        if (_coroutine == null)
            _coroutine = _corouitinesRunner.StartRoutine(TimerRoutine(action));
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