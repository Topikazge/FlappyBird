using UnityEngine;

public class PipeFacade : MonoBehaviour
{
    private PipeRoad _pipeRoad;
    private PipeMaker _wrapperPool;
    private PipeSpawner _pipeCreator;

    private void Start()
    {
        _pipeRoad = GetComponent<PipeRoad>();
        _wrapperPool = GetComponent<PipeMaker>();
        _pipeCreator = GetComponent<PipeSpawner>();
    }

    public void BeginSpawn()
    {
        _pipeCreator.StartSpawn();
    }

    public void ResetAll()
    {
        StopSpawn();
        DeletePipes();
    }

    public void StopSpawn()
    {
        _pipeCreator.StopSpawn();
    }

    public void DeletePipes()
    {
        _pipeRoad.ClearRoad();
        _wrapperPool.ClearPool();
    }
}
