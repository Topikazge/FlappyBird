using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DieMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ScorePassedPipes _score;

    private void Start()
    {
        _score.ChangeScore += SetScore;
    }

    private void SetScore(int value)
    {
        _text.text = value.ToString();
    }
}
