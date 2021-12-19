using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdForce : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Quaternion _rotationZero;
    private bool _canDown;
    private InteractableRigidBody2D _rigidBody;

    public event Action Force;
    public event Action Fall;

    private void Start()
    {
        _rigidBody = GetComponent<InteractableRigidBody2D>();
        SwitchStateMove(false);
        _rigidBody.Velocity(Vector2.zero);
        _rotationZero = Quaternion.Euler(0, 0, 0);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        if (_canDown)
        {
            Fall?.Invoke();
            if (Input.GetMouseButtonDown(0))
            {
                _rigidBody.Velocity(Vector2.zero);
                transform.rotation = _maxRotation;
                _rigidBody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
                Force?.Invoke();
            }        
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    public void StartMove()
    {
        SwitchStateMove(true);
    }

    public void StopMove()
    {
        SwitchStateMove(false);
    }

    public void ResetParameters()
    {
        SwitchStateMove(false);
        transform.rotation = _rotationZero;
        _rigidBody.Velocity( Vector2.zero);
    }

    private void SwitchStateMove(bool state)
    {
        _canDown = state;
        _rigidBody.Simulated = state;
    }
}
