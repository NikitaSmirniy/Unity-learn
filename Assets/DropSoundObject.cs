using UnityEngine;

public class DropSoundObject : MonoBehaviour
{
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audio.volume = collision.impulse.sqrMagnitude * 0.01f;
        audio.Play();
    }
}