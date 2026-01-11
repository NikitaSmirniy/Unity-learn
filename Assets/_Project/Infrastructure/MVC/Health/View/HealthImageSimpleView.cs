using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthImageSimpleView : HealthView
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public override void SetValue()
    {
        _image.fillAmount = Health.Value / Health.MaxValue;
    }
}