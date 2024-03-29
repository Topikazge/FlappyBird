using UnityEngine;

public class AnimationBird : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        SubscribingNotifications();
    }

    private void OnDoImpetus()
    {
        _animator.SetTrigger("Fly");
    }

    private void OnDoFall()
    {
        _animator.SetTrigger("Nothing");
    }

    private void SubscribingNotifications()
    {
        BirdForce birdForce = GetComponent<BirdForce>();
        birdForce.ForceEventHamdler += OnDoImpetus;
        birdForce.FallEventHamdler += OnDoFall;
    }
}
