using System;

public interface IPoolMonoModel
{
    int CreatedObjectsCount { get; }
    event Action CreatedObjectsCountChanged;
    event Action ActivatedObjectsCountChanged;
    int GetActiveObjectsCount();
}