using System;

public interface IWorkTimeTimerModel
{
    float CurrentWorkTime { get; }
    float WorkTime { get; }
    
    event Action WorkTimeChanged;
}