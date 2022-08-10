using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _vectorHorizontal;
    private InteractableTransform _transform;

    private void Start()
    {
        _transform = GetComponent<InteractableTransform>();
    }

    private void Update()
    {
        Vector2 _movement = new Vector2(_speed * Time.deltaTime * _vectorHorizontal, 0);
        _transform.Translate(_movement, Space.World);
    }

    public void SetMove(float vectorX, float speed)
    {
        _speed = speed;
        _vectorHorizontal = vectorX;
    }
}
