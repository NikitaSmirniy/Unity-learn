using Zenject;
using UnityEngine;

public class AdditionalDontDestroyOnLoad : MonoInstaller
{
    [SerializeField] private GameObject[] _toInstall;

    public override void InstallBindings()
    {
        foreach (var instaleable in _toInstall)
        {
            DontDestroyOnLoad(Instantiate(instaleable));
        }
    }
}