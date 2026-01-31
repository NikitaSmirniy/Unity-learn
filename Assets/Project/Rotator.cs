using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 _target;
    [SerializeField] private float _duration;
    [SerializeField] private LoopType _loopType;

    private void Start()
    {
        transform.DORotate(_target, _duration, RotateMode.FastBeyond360).SetLoops(-1, _loopType);
    }
}