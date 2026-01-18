using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorRenderer : MonoBehaviour
{
    [SerializeField] private float _defaultAlpha = 1;

    private Renderer _renderer;
    private IValueChangableObserver _model;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Reset();
    }

    private void OnEnable()
    {
        if (_model != null)
            _model.ValueChanged += SetAlpha;
    }

    private void OnDisable()
    {
        if (_model != null)
            _model.ValueChanged -= SetAlpha;
    }

    public void SetModel(IValueChangableObserver model)
    {
        if (model == null)
            return;

        if (_model != null)
            _model.ValueChanged -= SetAlpha;

        _model = model;

        _model.ValueChanged += SetAlpha;
    }
    
    public void SetAlpha(float value)
    {
        Color color = _renderer.material.color;

        color.a = value;

        _renderer.material.color = color;
    }
    
    private void Reset()
    {
        SetAlpha(_defaultAlpha);
    }
}