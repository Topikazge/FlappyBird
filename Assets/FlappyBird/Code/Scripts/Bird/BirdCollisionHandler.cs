using UnityEngine;
using System;

public class BirdCollisionHandler : MonoBehaviour
{
    private Bird _bird;

    private void Start()
    {
        _bird = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TryFind<ScoreZone>(collision.gameObject))
        {
            _bird.IncreaseScore();
        }
        else
        {
            _bird.Died();
        }
    }

    private bool TryFind<T>(GameObject target) where T: MonoBehaviour
    {
        if (target.TryGetComponent(out T scoreZone))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
