using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform _startCoordBird;
    [SerializeField] private GameObject _windowStart;
    [SerializeField] private GameObject _startWindow;
    [SerializeField] private GameObject _dieWindow;
    [SerializeField] private GameObject _scoreWindow;
    [SerializeField] private GameObject _birdObject;
    [SerializeField] private PipeFacade _pipeFacade;
    [SerializeField] private ScorePassedPipes _score;
    private BirdForce _birdForce;
    private Bird _bird;

    private void Awake()
    {
        _birdForce = _birdObject.GetComponent<BirdForce>();
        _bird = _birdObject.GetComponent<Bird>();

        _birdObject.transform.position = _startCoordBird.position;
        _bird.BirdDie += End;

        _startWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void Begin()
    {
        _startWindow.SetActive(false);
        _scoreWindow.SetActive(true);
        _pipeFacade.BeginSpawn();
        _bird.StartMove();
        _windowStart.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        _score.ResetScore();
        _dieWindow.SetActive(false);
        _scoreWindow.SetActive(false);
        _pipeFacade.DeletePipes();
        _birdObject.transform.position = _startCoordBird.position;
        _bird.ResetParameters();
        _startWindow.SetActive(true);
    }

    public void End()
    {
        _windowStart.SetActive(false);
        _scoreWindow.SetActive(false);
        _pipeFacade.StopSpawn();
        _bird.StopMove();
        _dieWindow.SetActive(true);
        Time.timeScale = 0;
    }
}
