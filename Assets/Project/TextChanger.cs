using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void Start()
    {
        Change();
    }

    private void Change()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(_text.DOText("Оппа текст заменился", 2f));
        seq.Append(_text.DOText("Оппа текст добавился", 5f).SetRelative());

        seq.Append(_text.DOText("Взлом текста", 5f, true, ScrambleMode.All))
            .Join(_text.DOColor(Color.green, duration: 2))
            .SetLoops(-1, LoopType.Yoyo);
    }
}