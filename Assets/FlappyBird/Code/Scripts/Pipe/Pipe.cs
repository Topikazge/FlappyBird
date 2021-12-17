using UnityEngine;

[RequireComponent(typeof(PipeMove))]
[RequireComponent(typeof(PipeCollisionHandler))]
public class Pipe : ComponentPool
{
    public InteractableTransform InteractTransform => _interactTransform;

    InteractableTransform _interactTransform;
    private PipeMove _pipeMove;
    private PipeRoad _pipeController;
    

    private void Awake()
    {
        _interactTransform = GetComponent<InteractableTransform>();
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
