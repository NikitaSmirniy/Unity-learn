using System;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private const string Fader_Path = "Fader";

    [SerializeField] private Animator animator;

    private static Fader _instance;

    public static Fader instance
    {
        get
        {
            if (_instance == null)
            {
                var prefab = Resources.Load<Fader>(Fader_Path);
                _instance = Instantiate(prefab);
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    public bool isFading { get; private set; }

    private Action _fadeInCallBack;
    private Action _fadeOutCallBack;

    public void FadeIn(Action fadedInCallBack)
    {
        if (isFading)
            return;

        isFading = true;
        _fadeInCallBack = fadedInCallBack;
        animator.SetBool("Faded", true);
    }

    public void FadeOut(Action fadedOutCallBack)
    {
        if (isFading)
            return;

        isFading = true;
        _fadeOutCallBack = fadedOutCallBack;
        animator.SetBool("Faded", false);
    }

    private void Handel_FadeInAnimatioOver()
    {
        _fadeInCallBack?.Invoke();
        _fadeInCallBack = null;
        isFading = false;
    }

    private void Handel_FadeOutAnimatioOver()
    {
        _fadeOutCallBack?.Invoke();
        _fadeOutCallBack = null;
        isFading = false;
    }
}