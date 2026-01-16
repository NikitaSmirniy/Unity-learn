using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageSimpleView : View
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public override void OnModelValueChanged()
    {
        _image.fillAmount = _model.Value / _model.MaxValue;
    }
}