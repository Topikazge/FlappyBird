using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _speedPipe;
    [SerializeField] private GameObject _roadPipe;
    [SerializeField] private float _spawnPeriod;
    [SerializeField] private Transform _maxPositionSpawnVertical;
    [SerializeField] private Transform _minPositionSpawnVertical;
    private float _maxPointSpawnVertical;
    private float _minPointSpawnVertical;
    private bool _canSpawn;
    private PipeRoad _pipeMover;
    private PipeMaker _pipePool;
    private IEnumerator _spawnMethod;

    private void Start()
    {
        _pipePool = GetComponent<PipeMaker>();
        _pipeMover = GetComponent<PipeRoad>();
        _maxPointSpawnVertical = _maxPositionSpawnVertical.position.y;
        _minPointSpawnVertical = _minPositionSpawnVertical.position.y;
        _spawnMethod = TimerSpawn();
    }

    public void StartSpawn()
    {
        _canSpawn = true;
        StartCoroutine(_spawnMethod);
    }

    public void StopSpawn()
    {
        _canSpawn = false;
        StopCoroutine(_spawnMethod);
    }

    private IEnumerator TimerSpawn()
    {
        while (_canSpawn)
        {
            yield return new WaitForSeconds(_spawnPeriod);
            Spawn();
        }
        yield return null;
    }

    private void Spawn()
    {
        Pipe pipe = _pipePool.GetPipe();
        pipe.transform.position = new Vector2(4.5f, Random.Range(_maxPointSpawnVertical, _minPointSpawnVertical));
        pipe.SetMovement(-1, _speedPipe);
        pipe.SetPipeRoad(_pipeMover);
        _pipeMover.AddPipeOnRoad(pipe);
    }
}

