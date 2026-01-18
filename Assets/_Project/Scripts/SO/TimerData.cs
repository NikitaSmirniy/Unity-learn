using UnityEngine;

[CreateAssetMenu(fileName = "TimerData", menuName = "TimerData", order = 51)]
public class TimerData : ScriptableObject
{
    [SerializeField] private float _minRandomTimerTime = 2;
    [SerializeField] private float _maxRandomTimerTime = 5;
    
    public  float MinRandomTimerTime =>  _minRandomTimerTime;
    public  float MaxRandomTimerTime => _maxRandomTimerTime;
}