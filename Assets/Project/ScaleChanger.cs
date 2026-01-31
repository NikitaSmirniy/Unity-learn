using DG.Tweening;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private LoopType _loopType;
    [SerializeField] private Vector3 _startPosition;

    private void Start()
    {
        transform.DOScale(1, _duration).SetLoops(-1, _loopType).From(_startPosition);
    }
}