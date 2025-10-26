using UnityEngine;

public class TestInteface : MonoBehaviour
{
    [SerializeField] private IInterface _interface;
    [SerializeField] private MonoBehaviour _monoInterface;
}

public interface IInterface
{

}