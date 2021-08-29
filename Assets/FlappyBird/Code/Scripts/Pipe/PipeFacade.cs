using UnityEngine;

public class PipeFacade : MonoBehaviour
{
    private PipeRoad _pipeController;
    private PipeMaker _wrapperPool;
    private PipeSpawner _pipeCreator;
    private void Start()
    {
        _pipeController = GetComponent<PipeRoad>();
        _wrapperPool = GetComponent<PipeMaker>();
        _pipeCreator = GetComponent<PipeSpawner>();
    }

    public void BeginSpawn()
    {
        _pipeCreator.StartSpawn();
    }

    public void Reset‘ll()
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
        _pipeController.ClearRoad();
        _wrapperPool.ClearPool();
    }
}
