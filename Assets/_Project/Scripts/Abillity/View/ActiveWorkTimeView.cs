using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ActiveWorkTimeView : MonoBehaviour
{
    [SerializeField] private float _isDoneAplha =0.5f;

    private Image _image;

    private IActionActivateObserver _model;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        if (_model != null)
            Subscribe();
    }

    private void OnDisable()
    {
        if (_model != null)
            UnSubscribe();
    }

    public void SetModel(IActionActivateObserver model)
    {
        if (model == null)
            return;

        if (_model != null)
            UnSubscribe();

        _model = model;

        Subscribe();

        OnActionIsDone();
    }

    private void OnActionStarted()
    {
        _image.fillAmount = 1;
        _image.color = Color.white;
    }
    
    private void OnActionEnded()
    {
        _image.color = Color.red;
        _image.fillAmount = 1;
    }

    private void OnActionIsDone()
    {
        _image.fillAmount = 1;
        _image.color = new  Color(1, 1, 1, _isDoneAplha);
    }
    
    private void Subscribe()
    {
        _model.ActionStarted += OnActionStarted;
        _model.ActionEnded += OnActionEnded;
        _model.ActionIsDone += OnActionIsDone;
    }

    private void UnSubscribe()
    {
        _model.ActionStarted -= OnActionStarted;
        _model.ActionEnded -= OnActionEnded;
        _model.ActionIsDone -= OnActionIsDone;
    }
}