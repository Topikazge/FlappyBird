using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DieMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ScorePassedPipes _score;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _score.ChangeScore += SetScore;
        FindObjectOfType<Bird>().BirdDie += _audioSource.Play;
    }

    private void SetScore(int value)
    {
        _text.text = value.ToString();
    }

    private void BirdDie()
    {
        _audioSource.Play();
    }
}
