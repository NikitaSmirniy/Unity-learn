using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "Ability/New Ability Data", order = 51)]
public class AbilityTimerData : ScriptableObject
{
    [SerializeField] private float _timeWork;
    [SerializeField] private float _cooldown;

    public float TimeWork => _timeWork;
    public float Cooldown => _cooldown;
}