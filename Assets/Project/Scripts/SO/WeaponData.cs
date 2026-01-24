using UnityEngine;

[CreateAssetMenu(fileName =  "WeaponData", menuName = "Weapon Data")]
public class WeaponData : ScriptableObject
{
    [field: SerializeField] public AudioClip AudioClip { get; private set; }
}