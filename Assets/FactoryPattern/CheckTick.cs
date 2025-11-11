using System;
using UnityEngine;
using Zenject;

[Serializable]
public class CheckTick : ITickable
{
    public void Tick()
    {
        Debug.Log("penis");
    }

    //Container.Bind<Player>().FromFactory<PlayerFactory>();
    //Container.Bind<Player>().FromMethod(SomeMethod);
    //Container.Bind<Player>().FromMethod(SomeMethod);
    Player SomeMethod(InjectContext injectContext)
    {
        return new Player();
    }
}