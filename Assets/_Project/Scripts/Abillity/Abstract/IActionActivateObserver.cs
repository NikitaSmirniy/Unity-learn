using System;
using Action = System.Action;

public interface IActionActivateObserver
{
    event Action ActionStarted;
    event Action ActionEnded;
    event Action ActionIsDone;
}