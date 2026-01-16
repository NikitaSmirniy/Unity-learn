using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private WorkTimerView _workTimerView;
    [SerializeField] private CooldownTimerView cooldownTimerView;
    [SerializeField] private ActiveWorkTimeView activeWorkTimeView;
    
    public void Init(ITimerModel timerModel, IActionActivateObserver actionActivateObserver)
    {
        if (timerModel == null)
            return;
        
        if(_workTimerView != null)
            _workTimerView.SetModel(timerModel);
        
        if(cooldownTimerView != null)
            cooldownTimerView.SetModel(timerModel);
        
        if(activeWorkTimeView != null)
            activeWorkTimeView.SetModel(actionActivateObserver);
    }
}