using System;
using TMPro;
using UnityEngine;

public class ScorePassedPipes : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int _score;

    public event Action<int> ChangeScore;

    private void Start()
    {
        _text.text = _score.ToString();
        FindObjectOfType<Bird>().ScoreChange += OnChangeScore;
    }

    public void OnChangeScore()
    {
        IncreaseScore();
        NotificateScore();
    }

    public void ResetScore()
    {
        _score = 0;
        NotificateScore();
    }

    private void NotificateScore()
    {
        _text.text = _score.ToString();
        ChangeScore?.Invoke(_score);
    }

    private void IncreaseScore()
    {
        _score++;
    }
}
