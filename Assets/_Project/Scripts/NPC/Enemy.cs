using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(DetectorCitizen))]
public class Enemy : NPC
{
    private DetectorCitizen _detectorCitizen;

    public event Action<Enemy> ReachedTarget;

    private void Awake()
    {
        _detectorCitizen = GetComponent<DetectorCitizen>();
        _moverHandler = GetComponent<MoverHandler>();
        SetDefaultValues();
    }

    private void OnEnable()
    {
        _detectorCitizen.Touched += PerformAttack;
        _detectorCitizen.Touched += FinishLife;
    }

    private void OnDisable()
    {
        _detectorCitizen.Touched -= PerformAttack;
        _detectorCitizen.Touched -= FinishLife;
    }

    private void FinishLife(Citizen _)
    {
        ReachedTarget?.Invoke(this);
    }

    public override void SetDefaultValues()
    {
        transform.rotation = Quaternion.identity;
        _detectorCitizen.SetDefault();
    }

    private void PerformAttack(Citizen citizen)
    {
        citizen.DamageTaker.TakeDamage();
    }
}