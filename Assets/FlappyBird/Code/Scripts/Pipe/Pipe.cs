using UnityEngine;

[RequireComponent(typeof(PipeMove))]
[RequireComponent(typeof(PipeCollisionHandler))]
public class Pipe : ComponentPool
{
    private PipeMove _pipeMove;
    private PipeRoad _pipeController;

    private void Awake()
    {
        _pipeMove = GetComponent<PipeMove>();
    }

    public void SetPipeController(PipeRoad pipeController)
    {
        _pipeController = pipeController;
    }
    public void SetMove(float vectorX, float speed)
    {
        _pipeMove.SetMove(vectorX, speed);
    }

    public void OnEnterFinish()
    {
        _pipeController.RemovePipeOnRoad(this);
    }
}
