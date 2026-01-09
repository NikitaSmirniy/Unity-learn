using UnityEngine;
using UnityEngine.UI;

public class ToggleView : MonoBehaviour
{
    [SerializeField] public Toggle _toggle;

    public Toggle.ToggleEvent ToggleEvent => _toggle.onValueChanged;

    public void SetAsActive(float _ = 0) =>
        _toggle.isOn = true;
}