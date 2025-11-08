using System.Threading;
using UnityEngine;

public class SimpleThread : MonoBehaviour
{
    [SerializeField] private int _i = 1;

    private void Start()
    {
        new Thread(() =>
            {
                while (true)
                {
                    _i++;
                }
            }).Start();
    }
}