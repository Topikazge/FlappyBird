using UnityEngine;

public class SoundPlayerBird : MonoBehaviour
{
    [SerializeField] private AudioClip _flap;
    [SerializeField] private AudioSource _pipePassage;

    private AudioSource _audioSource;


    private void Start()
    {
        GetComponent<Bird>().ScoreChange += OnPlayChangeScore;
        GetComponent<BirdForce>().Force += Flap;
        _audioSource = GetComponent<AudioSource>();
    }

    public void Flap()
    {
        _audioSource.Play();
    }

    public void OnPlayChangeScore()
    {
        _pipePassage.Play();
    }
}
