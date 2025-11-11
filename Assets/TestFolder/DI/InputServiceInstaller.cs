using UnityEngine;
using Zenject;

public class InputServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
            Container.BindInterfacesAndSelfTo<KeyBoardInput>().AsSingle().NonLazy();
    }
}