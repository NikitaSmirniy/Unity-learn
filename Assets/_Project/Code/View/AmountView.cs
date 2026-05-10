using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class AmountView : MonoBehaviour
{
    private TextMeshProUGUI _numberOfItemText;

    private void Awake()
    {
        _numberOfItemText = GetComponent<TextMeshProUGUI>();
    }

    public void SetAmount(int amount)
    {
        _numberOfItemText.text = amount.ToString();
    }
}