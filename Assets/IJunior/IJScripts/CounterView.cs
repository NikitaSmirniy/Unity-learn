using TMPro;
using UnityEngine;

namespace IJuniorScripts
{
    public class CounterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private Counter _counter;

        private void Awake()
        {
            _counter = GetComponent<Counter>();
        }

        private void OnEnable()
        {
            _counter.ScoreChanged += ShowScore;
        }

        private void OnDisable()
        {
            _counter.ScoreChanged -= ShowScore;
        }

        private void ShowScore(float totalScore) =>
            _scoreText.text = totalScore.ToString();
    }
}