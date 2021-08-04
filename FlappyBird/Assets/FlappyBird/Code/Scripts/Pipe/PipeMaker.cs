using UnityEngine;

public class PipeMaker : MonoBehaviour
{
    [SerializeField] private Pipe _prefab;

    private PipesPool _pipePool;

    private void Start()
    {
        _pipePool = GetComponent<PipesPool>();
        _pipePool.Initialization(_prefab);
    }

    public Pipe Get()
    {
        return _pipePool.Get();
    }

    public void ReturnToPool(Pipe objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        _pipePool.ReturnToPool(objectToReturn);
    }

    public void ClearPool()
    {
        _pipePool.ClearPool();
    }
}
