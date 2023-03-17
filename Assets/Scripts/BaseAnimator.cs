using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class BaseAnimator : MonoBehaviour
{
    [SerializeField] protected float _dieAnimDuration;

    protected Animator _animator;

    protected void Hit()
    {
        _animator.SetTrigger("Hit");
    }

    protected abstract void Die();

    protected abstract void AssignAction();

    protected abstract void UnassignAction();
}