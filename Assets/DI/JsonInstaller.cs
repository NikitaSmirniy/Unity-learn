using Zenject;

public class JsonInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SaverJson>().AsSingle();
        Container.Bind<LoaderJson>().AsSingle();
    }
}