using System;
using TMPro;
using UnityEngine;

public class ScorePipe : MonoBehaviour
{
    private int _score;

    public event Action<int> ChangeScoreEventHandler;

    private void Start()
    {
        FindObjectOfType<Bird>().ScoreChange += OnChangeScore;
        NotificateScore();
    }

    public void OnChangeScore()
    {
        IncreaseScore();
    }

    public void ResetScore()
    {
        ChangeScore(0);
    }

    private void NotificateScore()
    {
        ChangeScoreEventHandler?.Invoke(_score);
    }

    private void IncreaseScore()
    {
        ChangeScore(++_score);
    }

    private void ChangeScore(int value)
    {
        _score = value;
        NotificateScore();
    }
}