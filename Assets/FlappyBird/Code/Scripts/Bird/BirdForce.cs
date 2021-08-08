using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdForce : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;

    [SerializeField] private float _tapForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private bool _canDown;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Quaternion _rotationZero = Quaternion.Euler(0, 0, 0);

    private Rigidbody2D _rigidBody2d;

    public event Action Force;
    public event Action Fall;

    private void Start()
    {
        _rigidBody2d = GetComponent<Rigidbody2D>();

        _rigidBody2d.simulated = false;

        _rigidBody2d.velocity = Vector2.zero;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        if (_canDown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _rigidBody2d.velocity = new Vector2(0, 0);
                transform.rotation = _maxRotation;
                _rigidBody2d.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
                Force?.Invoke();
            }
            Fall?.Invoke();
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    public void StartMove()
    {
        _canDown = true;
        _rigidBody2d.simulated = true;
    }

    public void StopMove()
    {
        _canDown = false;
        _rigidBody2d.simulated = false;
    }
    public void ResetParameters()
    {
        _canDown = false;
        _rigidBody2d.simulated = false;
        transform.rotation = _rotationZero;
        _rigidBody2d.velocity = new Vector2(0, 0);
    }
}
