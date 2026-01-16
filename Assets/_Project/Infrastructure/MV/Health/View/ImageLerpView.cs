using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageLerpView : View
{
    [SerializeField] private float _lerpSpeed = 3;

    private Image _image;
    private Coroutine _coroutine;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public override void OnModelValueChanged()
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
        var end = GetNormalizedValue();
        var lerpSpeed = GetLerpSpeed();
        
        while (_image.fillAmount != target)
        {
            _image.fillAmount = Mathf.Lerp(_image.fillAmount, end, lerpSpeed);
            
            yield return null;
        }

        _coroutine = null;
    }

    private float GetLerpSpeed() =>
        _lerpSpeed * Time.deltaTime;

    private float GetNormalizedValue() =>
        _model.Value / _model.MaxValue;
}