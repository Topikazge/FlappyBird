using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T: ComponentPool
{
    private T _object;
    private Queue<T> _objects = new Queue<T>();

    public void Initialization(T prefab)
    {
        _object = prefab;
    }

    public T Get()
    {
        if (_objects.Count == 0)
        {
            AddNumberObjects(1);
            return _objects.Dequeue();
        }
        else
        {
            return _objects.Dequeue();
        }     
    }

    public void ReturnToPool(T objectToReturn)
    {
        if (objectToReturn is T)
        {
            _objects.Enqueue(objectToReturn);
        }

    }
    public void ClearPool()
    {
        _objects.Clear();
    }

    protected void AddNumberObjects(int count)
    {
        var newObject = Instantiate<T>(_object);
        _objects.Enqueue(newObject);
    }
}
