using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private SoundPlayerBird _soundPlayerBird;

    public event Action ScoreChange;
    public event Action BirdDie;

    private void Start()
    {
        _soundPlayerBird = GetComponent<SoundPlayerBird>();
    }

    public void IncreaseScore()
    {
        ScoreChange.Invoke();
    }

    public void Died()
    {
        BirdDie.Invoke();
    }
}
