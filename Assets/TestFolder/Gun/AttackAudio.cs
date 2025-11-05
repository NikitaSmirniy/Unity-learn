using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAudio : MonoBehaviour
{
    [SerializeField] private AudioClip _shootClip;

    private AudioSource _audioSource;
    private Weapon _weapon;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _weapon = GetComponent<Weapon>();
    }

    private void OnEnable()
    {
        _weapon.AttackHappened += PerformAudio;
    }

    private void OnDisable()
    {
        _weapon.AttackHappened -= PerformAudio;
    }

    private void PerformAudio()
    {
        _audioSource.PlayOneShot(_shootClip);
    }
}