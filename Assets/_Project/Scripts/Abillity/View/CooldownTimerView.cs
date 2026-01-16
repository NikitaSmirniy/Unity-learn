using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CooldownTimerView : MonoBehaviour
{
    private Image _image;

    private ICooldownTimerModel _model;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        if (_model != null)
            _model.CooldownChanged += ModelValueChanged;
    }

    private void OnDisable()
    {
        if (_model != null)
            _model.CooldownChanged -= ModelValueChanged;
    }

    public void SetModel(ICooldownTimerModel model)
    {
        if (model == null)
            return;

        if (_model != null)
            _model.CooldownChanged -= ModelValueChanged;

        _model = model;

        _model.CooldownChanged += ModelValueChanged;

        ModelValueChanged();
    }

    private void ModelValueChanged()
    {
        _image.fillAmount = _model.CurrentCooldown / _model.Cooldown;
    }
}