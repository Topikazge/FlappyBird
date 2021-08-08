using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{
    private Bird _bird;

    private void Start()
    {
        _bird = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ScoreZone>(out ScoreZone scoreZone))
        {
            _bird.IncreaseScore();
        }
        else
        {
            _bird.Died();
        }
    }
}
