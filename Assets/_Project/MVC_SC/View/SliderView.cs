using UnityEngine;
using UnityEngine.UI;

public class SliderView : MonoBehaviour
{
    [SerializeField]private Slider _slider;

    public Slider.SliderEvent SliderEvent => _slider.onValueChanged;
}