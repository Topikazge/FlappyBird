using System.Collections.Generic;
using UnityEngine;

public class PipeRoad : MonoBehaviour
{
    private List<Pipe> _pipesOnRoad;
    private PipeMaker _pipeMaker;

    private void Start()
    {
        _pipesOnRoad = new List<Pipe>();
        _pipeMaker = GetComponent<PipeMaker>();
    }

    public void AddPipeOnRoad(Pipe pipe)
    {
        if (pipe is Pipe)
        {
            _pipesOnRoad.Add(pipe);
            pipe.transform.SetParent(transform);
        }
    }

    public void RemovePipeOnRoad(Pipe pipe)
    {
        if (pipe is Pipe)
        {
            _pipesOnRoad.Remove(pipe);
            _pipeMaker.ReturnToPool(pipe);
        }
    }

    public void ClearRoad()
    {
        for (int i = 0; i < _pipesOnRoad.Count; i++)
        {
            Destroy(_pipesOnRoad[i].gameObject);
        }
        _pipesOnRoad.Clear();
    }
}
