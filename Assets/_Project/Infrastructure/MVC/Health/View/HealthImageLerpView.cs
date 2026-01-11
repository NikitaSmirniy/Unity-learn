using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthImageLerpView : HealthView
{
    [SerializeField] private float _lerpSpeed = 3;

    private Image _image;
    private Coroutine _coroutine;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public override void SetValue()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(SetSmoothValueRoutine(GetNormalizedValue()));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(SetSmoothValueRoutine(GetNormalizedValue()));
        }
    }

    private IEnumerator SetSmoothValueRoutine(float target)
    {
        while (_image.fillAmount != target)
        {
            _image.fillAmount = Mathf.Lerp(_image.fillAmount, GetNormalizedValue(), GetLerpSpeed());

            yield return null;
        }

        _coroutine = null;
    }

    private float GetLerpSpeed() =>
        _lerpSpeed * Time.deltaTime;

    private float GetNormalizedValue() =>
        Health.Value / Health.MaxValue;
}