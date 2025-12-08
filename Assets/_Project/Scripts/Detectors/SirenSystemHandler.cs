using UnityEngine;

[RequireComponent(typeof(ThiefDetector))]
[RequireComponent(typeof(AudioPlayer))]
public class SirenSystemHandler : MonoBehaviour
{
    private ThiefDetector _thiefDetector;
    private AudioPlayer _audioPlayer;

    private AudioClip _sirenClip;

    private void Awake()
    {
        _thiefDetector = GetComponent<ThiefDetector>();
        _audioPlayer = GetComponent<AudioPlayer>();
        _audioPlayer.SetClip(_sirenClip);
    }

    private void OnEnable()
    {
        _thiefDetector.Touched += _audioPlayer.Play;
        _thiefDetector.Touched += StartChase;
        _thiefDetector.Untouched += _audioPlayer.Stop;
        _thiefDetector.Untouched += StopChase;
    }

    private void OnDisable()
    {
        _thiefDetector.Touched -= _audioPlayer.Play;
        _thiefDetector.Touched -= StartChase;
        _thiefDetector.Untouched -= _audioPlayer.Stop;
        _thiefDetector.Untouched -= StopChase;
    }

    public void Init(AudioClip sirenClip)
    {
        _sirenClip = sirenClip;
    }

    private void StartChase() =>
        _thiefDetector.TouchedComponent.SetIsDetected(true);

    private void StopChase() =>
        _thiefDetector.TouchedComponent.SetIsDetected(false);
}