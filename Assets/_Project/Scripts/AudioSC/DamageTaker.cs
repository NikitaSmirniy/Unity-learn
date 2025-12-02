using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DamageTaker : MonoBehaviour
{
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void TakeDamage()
    {
        _audio.PlayOneShot(_audio.clip);
    }
}