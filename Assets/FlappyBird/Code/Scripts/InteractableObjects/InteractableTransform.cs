using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTransform : MonoBehaviour
{
    public Vector2 Position
    {
        get
        {
           return transform.position;
        }
        set
        {
            SetPosition(value);
        }
    }
            
    public void Translate(Vector2 movement,Space space = Space.World)
    {
        if (movement == null)
            return;
        transform.Translate(movement, Space.World);
    }

    public void SetParent(Transform @object)
    {
        transform.SetParent(@object);
    }

    public void Rotation(Quaternion quaternion)
    {
        if (quaternion == null)
            return;
        transform.rotation = quaternion;
    }

    private void SetPosition(Vector2 position)
    {
        if (position == null)
            return;
        transform.position = position;
    }

}
