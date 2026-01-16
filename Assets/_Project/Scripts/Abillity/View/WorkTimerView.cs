using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class WorkTimerView : MonoBehaviour
{
    private Image _image;

    private IWorkTimeTimerModel _model;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        if (_model != null)
            _model.WorkTimeChanged += OnModelValueChanged;
    }

    private void OnDisable()
    {
        if (_model != null)
            _model.WorkTimeChanged -= OnModelValueChanged;
    }

    public void SetModel(IWorkTimeTimerModel model)
    {
        if (model == null)
            return;

        if (_model != null)
            _model.WorkTimeChanged -= OnModelValueChanged;

        _model = model;

        _model.WorkTimeChanged += OnModelValueChanged;

        OnModelValueChanged();
    }

    private void OnModelValueChanged()
    {
        _image.fillAmount = _model.CurrentWorkTime / _model.WorkTime;
    }
}