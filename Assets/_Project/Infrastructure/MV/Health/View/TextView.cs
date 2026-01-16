using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextView : View
{
    private  TextMeshProUGUI _text;

    private void Awake()
    {
        _text =  GetComponent<TextMeshProUGUI>();
    }

    public override void OnModelValueChanged()
    {
        _text.text = $"{_model.Value}/{_model.MaxValue}";
    }
}