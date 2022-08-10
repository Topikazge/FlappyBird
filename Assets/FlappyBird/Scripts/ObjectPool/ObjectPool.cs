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

    public T GetObject()
    {
        if (_objects.Count == 0)
        {
            AddObjects();
            return _objects.Dequeue();
        }
        else
        {
            return _objects.Dequeue();
        }     
    }

    public void ReturnInPool(T objectToReturn)
    {
        if ((objectToReturn is not null) && (objectToReturn is T))
        {
            _objects.Enqueue(objectToReturn);
        }

    }
    public void ClearPool()
    {
        _objects.Clear();
    }

    protected void AddObjects()
    {
        var newObject = Instantiate<T>(_object);
        _objects.Enqueue(newObject);
    }
}
