using TMPro;
using UnityEngine;

public class ValueChangedView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _valueText;

    private IValueChangedPublisher _valueChangedPublisher;

    private void Awake()
    {
        _valueText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        if (_valueChangedPublisher != null)
            _valueChangedPublisher.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        if (_valueChangedPublisher != null)
            _valueChangedPublisher.ValueChanged -= OnValueChanged;
    }

    public void Init(IValueChangedPublisher valueChangedPublisher)
    {
        _valueChangedPublisher = valueChangedPublisher;
        _valueChangedPublisher.ValueChanged += OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _valueText.text = $"Счёт: {value}";
    }
}