using UnityEngine;

[RequireComponent(typeof(PipeMove))]
[RequireComponent(typeof(PipeCollisionHandler))]
public class Pipe : ComponentPool
{
    private InteractableTransform _interactTransform;
    private PipeMove _pipeMove;
    private PipeRoad _pipeRoad;

    public InteractableTransform InteractTransform => _interactTransform;

    private void Awake()
    {
        _interactTransform = GetComponent<InteractableTransform>();
        _pipeMove = GetComponent<PipeMove>();
    }

    public void SetPipeRoad(PipeRoad pipeController)
    {
        _pipeRoad = pipeController;
    }

    public void SetMovement(float vectorX, float speed)
    {
        _pipeMove.SetMove(vectorX, speed);
    }

    public void OnEnterFinish()
    {
        _pipeRoad.RemovePipeWithRoad(this);
    }
}
