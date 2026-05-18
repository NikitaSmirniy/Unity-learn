using System.Collections;

namespace _Project.Code.Spawners
{
    public interface ICoroutineRunner
    {
        void RunCoroutine(IEnumerator coroutine);
    }
}