using UnityEngine;
using Zenject;

public class JsonHandler : MonoBehaviour
{
    [SerializeField] private JsonTestClass _player;

    private SaverJson _saverJson;
    private LoaderJson _loaderJson;

    [Inject]
    public void Contructer(SaverJson saverJson, LoaderJson loaderJson)
    {
        _saverJson = saverJson;
        _loaderJson = loaderJson;
    }

    public void Save()
    {
        _saverJson.Save(_player);
    }

    public void Load()
    {
        _loaderJson.Load(_player);
    }
}