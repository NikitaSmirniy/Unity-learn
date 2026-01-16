using UnityEngine;

[CreateAssetMenu(fileName = "AbilityActionData", menuName = "Ability/New Ability Action Data", order = 51)]
public class AbilityActionData : ScriptableObject
{
    [SerializeField] private float _damagePerSecond;
    [SerializeField] private float _healPerSecond;

    public float DamagePerSecond => _damagePerSecond;
    public float HealPerSecond => _healPerSecond;
}