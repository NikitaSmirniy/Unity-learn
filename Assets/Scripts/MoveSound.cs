using UnityEngine;

public class MoveSound : MonoBehaviour
{
    [SerializeField] private AudioClip stepAudioClip;

    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void StepSound()
    {
        audio.PlayOneShot(stepAudioClip);
    }
}