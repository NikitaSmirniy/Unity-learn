using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponAmmoView : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    private void OnEnable()
    {
        _weapon.AttackHappened += DisplayAmount;
    }

    private void OnDisable()
    {
        _weapon.AttackHappened -= DisplayAmount;
    }

    private void DisplayAmount()
    {
        var totalAmount = _weapon.Damage;
        _textMeshProUGUI.text = totalAmount.ToString();
    }

    private void ShowEnoughMessage()
    {
        _textMeshProUGUI.text = $"Не достаточно патрон ";
    }
}