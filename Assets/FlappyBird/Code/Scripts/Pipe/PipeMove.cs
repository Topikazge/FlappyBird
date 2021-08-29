using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _vectorX;

    /*   public float Speed { set => _speed = value; }
       public float VectorX { set => _vectorX = value; }*/

    public void SetMove(float vectorX, float speed)
    {
        _speed = speed;
        _vectorX = vectorX;
    }


    private void Update()
    {
        Vector2 _movement = new Vector2(_speed * Time.deltaTime * _vectorX, 0);
        transform.Translate(_movement, Space.World);
    }

}
