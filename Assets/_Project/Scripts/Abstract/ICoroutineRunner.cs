using System.Collections;
using UnityEngine;

public interface ICoroutinesRunner
{
    Coroutine StartRoutine(IEnumerator enumerator);
}