using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _enemy.GetHitAction += Hit;
        _enemy.DieAction += Die;
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity == Vector2.zero)
        {
            _animator.SetBool("Run", false);
        }
        else
        {
            _animator.SetBool("Run", true);
        }
    }

    private void Hit()
    {
        _animator.SetTrigger("Hit");
    }

    private void Die()
    {
        //StartCoroutine(DieCorutine());
    }
}