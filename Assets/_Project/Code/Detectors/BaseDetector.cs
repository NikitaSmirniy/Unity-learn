using System;
using UnityEngine;

namespace _Project.Code
{
    public class BaseDetector : MonoBehaviour
    {
        public event Action<Base> Detected;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Base result))
            {
                Detected?.Invoke(result);
            }
        }
    }
}