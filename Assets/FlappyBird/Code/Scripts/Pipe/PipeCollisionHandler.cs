using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pipe))]
public class PipeCollisionHandler : MonoBehaviour
{
    private Pipe _pipe;

    private void Start()
    {
        _pipe = GetComponent<Pipe>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PipeFinishLine>(out PipeFinishLine pipeFinish))
        {
            _pipe.OnEnterFinish();
        }
    }
}
