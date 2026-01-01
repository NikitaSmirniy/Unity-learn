using UnityEngine;
using UnityEngine.UI;

public class ConcreteScreen : AbstractScreen<ConcreteViewModel>
{
    [SerializeField] private Text _health;
    [SerializeField] private Button _someButton;
    
    private ConcreteViewModel _model;

    private void Start()
    {
        _someButton.onClick.AddListener(AddHealth);
    }

    protected override void OnBind(ConcreteViewModel model)
    {
        _model = model;
        _health.text = model.Health.ToString();
    }

    private void AddHealth()
    {
        _model.DoSomething();
    }
}
