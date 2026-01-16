using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundsData", menuName = "ScriptableObjects/SoundsData", order = 51)]
public class SoundsData : ScriptableObject
{
    [SerializeField] private List<SoundInfo> _soundInfos;
    
    public IReadOnlyList<SoundInfo> SoundInfos => _soundInfos;
}