using UnityEngine;

public class InvokeAttackByInput : MonoBehaviour
{
    [SerializeField] private Weapon _attackBehaviour;

    private void Awake()
    {
        _attackBehaviour = GetComponent<Weapon>();
    }

    private const KeyCode LeftMouseButton = KeyCode.Mouse0;

    private void Update()
    {
        if (Input.GetKeyDown(LeftMouseButton))
        {
            _attackBehaviour.PerformAttack();
            print("Mouse0");
        }
    }
}