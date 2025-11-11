using UnityEngine;
using Zenject;

public class InputServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
<<<<<<< HEAD
            Container.BindInterfacesAndSelfTo<KeyBoardInput>().AsSingle().NonLazy();
=======
            Container.BindInterfacesAndSelfTo<KeyBoardInput>().AsSingle();
>>>>>>> Animation
    }
}