using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private int _maxPlayerHealth;
    [SerializeField] private HealthView[] _healthTextViews;
    [SerializeField] private ButtonView _attackButtonView;
    [SerializeField] private ButtonView _healButtonView;
    [SerializeField] private int _damage;
    [SerializeField] private int _healAmount;

    private ButtonAttackPresenter _buttonAttackPresenter;
    private ButtonHealPresenter _buttonHealPresenter;

    private void Awake()
    {
        Initialize();
    }

    private void OnDisable()
    {
        _buttonAttackPresenter.Dispose();
        _buttonHealPresenter.Dispose();
    }

    private void Initialize()
    {
        Health health = new Health(_maxPlayerHealth);

        _playerHealth.Init(health);

        Attackeer attackeer = new Attackeer(_damage, _playerHealth);
        _buttonAttackPresenter = new ButtonAttackPresenter(attackeer, _attackButtonView);

        Healer healer = new Healer(_healAmount, _playerHealth);
        _buttonHealPresenter = new ButtonHealPresenter(healer, _healButtonView);

        foreach (var healthTextView in _healthTextViews)
            healthTextView.Init(health);
    }
}