using UnityEngine;

public class AuraView : MonoBehaviour
{
    private IActionActivateObserver _model;

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
    }

    private void OnActionStarted()
    {
        gameObject.SetActive(true);
    }
    
    private void OnActionEnded()
    {
        gameObject.SetActive(false);
    }

    private void Subscribe()
    {
        _model.ActionStarted += OnActionStarted;
        _model.ActionEnded += OnActionEnded;
    }

    private void UnSubscribe()
    {
        _model.ActionStarted -= OnActionStarted;
        _model.ActionEnded -= OnActionEnded;
    }
}