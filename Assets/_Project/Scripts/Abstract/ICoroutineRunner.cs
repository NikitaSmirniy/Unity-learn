using System.Collections;
using UnityEngine;

public interface ICorouitinesRunner
{
    Coroutine StartRoutine(IEnumerator enumerator);
}