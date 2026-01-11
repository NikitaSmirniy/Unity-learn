using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthTextView : HealthView
{
    private  TextMeshProUGUI _text;

    private void Awake()
    {
        _text =  GetComponent<TextMeshProUGUI>();
    }

    public override void SetValue()
    {
        _text.text = $"{Health.Value}/{Health.MaxValue}";
    }
}