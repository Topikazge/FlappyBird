using UnityEngine;

public class PipeMaker : MonoBehaviour
{
    [SerializeField] private Pipe _prefabPipe;

    private PipesPool _pipePool;

    private void Start()
    {
        _pipePool = GetComponent<PipesPool>();
        _pipePool.Initialization(_prefabPipe);
    }

    public Pipe GetPipe()
    {
        return _pipePool.GetObject();
    }

    public void ReturnInPool(Pipe pipe)
    {
        pipe.gameObject.SetActive(false);
        _pipePool.ReturnInPool(pipe);
    }

    public void ClearPool()
    {
        _pipePool.ClearPool();
    }
}
