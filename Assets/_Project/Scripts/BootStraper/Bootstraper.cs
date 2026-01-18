using System.Collections;
using UnityEngine;

public class Bootstraper : MonoBehaviour,ICorouitinesRunner
{
    public Coroutine StartRoutine(IEnumerator enumerator)
    {
        return StartRoutine(enumerator);
    }
}