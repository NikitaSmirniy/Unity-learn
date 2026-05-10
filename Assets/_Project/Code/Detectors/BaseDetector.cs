using System;
using UnityEngine;

namespace _Project.Code
{
    public class BaseDetector : MonoBehaviour
    {
        public event Action Detected;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Base _))
            {
                Detected?.Invoke();
            }
        }
    }
}