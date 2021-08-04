using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _speedPipe;
    [SerializeField] private GameObject _roadPipe;
    [SerializeField] private float _spawnPeriod;

    [SerializeField] private Transform _maxPositionSpawnY;
    [SerializeField] private Transform _minPositionSpawnY;

    private float _maxpPoimtSpawnY;
    private float _mintomPoimtSpawnY;

    private bool _isCanSpawned;
    private PipeRoad _pipeMover;
    private PipeMaker _pipePool;
    private IEnumerator _spawnMethod;

    private void Start()
    {
        _pipePool = GetComponent<PipeMaker>();
        _pipeMover = GetComponent<PipeRoad>();

        _maxpPoimtSpawnY = _maxPositionSpawnY.position.y;
        _mintomPoimtSpawnY = _minPositionSpawnY.position.y;

        _spawnMethod = TimerSpawn();
    }

    public void StartSpawn()
    {
        _isCanSpawned = true;
        StartCoroutine(_spawnMethod);
    }

    public void StopSpawn()
    {
        _isCanSpawned = false;
        StopCoroutine(_spawnMethod);
    }

    private IEnumerator TimerSpawn()
    {
        while (_isCanSpawned)
        {
            yield return new WaitForSeconds(_spawnPeriod);
            Spawn();
        }
        yield return null;
    }

    private void Spawn()
    {
        Pipe pipe = _pipePool.Get();
        pipe.transform.position = new Vector2(4.5f, Random.Range(_maxpPoimtSpawnY, _mintomPoimtSpawnY));
        pipe.SetMove(-1, _speedPipe);
        pipe.SetPipeController(_pipeMover);
        _pipeMover.AddPipeOnRoad(pipe);
    }
}

