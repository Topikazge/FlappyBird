using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableRigidBody2D : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public bool Simulated
    {
        get
        {
            return _rigidbody.simulated;
        }
        set
        {
            _rigidbody.simulated = value;
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Velocity(Vector2 vector)
    {
        if (vector == null)
            return;
        _rigidbody.velocity = vector;
    }

    public void AddForce(Vector2 vector, ForceMode2D force = ForceMode2D.Force)
    {
        if (vector == null)
            return;
        _rigidbody.AddForce(vector, ForceMode2D.Force);
    }
}