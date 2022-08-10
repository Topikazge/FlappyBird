using UnityEngine;

public class SoundPlayerBird : MonoBehaviour
{
    [SerializeField] private AudioClip _flap;
    [SerializeField] private AudioClip _fall;
    [SerializeField] private AudioClip _pipePassage;

    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Bird bird = GetComponent<Bird>();
        bird.ScoreChange += IncreaseScore;
        bird.BirdDie += Fall;
        GetComponent<BirdForce>().ForceEventHamdler += Flap;
    }

    public void Flap()
    {
        _audioSource.PlayOneShot(_flap);
    }
    public void Fall()
    {
        _audioSource.PlayOneShot(_fall);
    }
    public void IncreaseScore()
    {
        _audioSource.PlayOneShot(_pipePassage);
    }

    public void StopPlayback()
    {
        _audioSource.Stop();
    }
}
