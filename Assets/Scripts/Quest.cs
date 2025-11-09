using UnityEngine;
using DialogueEditor;

public class Quest : MonoBehaviour
{
    [SerializeField] private int Money;
    [SerializeField] private bool HaveProbirka;
    [SerializeField] private int _dialogCount;
    [SerializeField] private AudioSource _audioSource;

    public void SetValues()
    {
        var instance = ConversationManager.Instance;

        instance.SetInt("Money", Money);
        instance.SetInt("DialogCount", _dialogCount);
        instance.SetBool("HaveProbirka", HaveProbirka);
    }

    public void GetValue()
    {
        _dialogCount = ConversationManager.Instance.GetInt("DialogCount");
    }

    public void GiveReward()
    {
        _audioSource.Play();
        print("Вы получили 1000 К руб.");
    }
}