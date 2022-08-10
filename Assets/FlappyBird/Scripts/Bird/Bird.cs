using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private SoundPlayerBird _soundPlayerBird;
    private BirdForce _birdForce;

    public event Action ScoreChange;
    public event Action BirdDie;

    private void Start()
    {
        _birdForce = GetComponent<BirdForce>();
        _soundPlayerBird = GetComponent<SoundPlayerBird>();
    }

    public void IncreaseScore()
    {
        ScoreChange?.Invoke();
    }

    public void Died()
    {
        BirdDie?.Invoke();
    }

    public void StartMove()
    {
        _birdForce.StartMove();
    }

    public void StopMove()
    {
        _birdForce.StopMove();
    }

    public void ResetParameters()
    {
        _birdForce.ResetParameters();
        _soundPlayerBird.StopPlayback();
    }
}
