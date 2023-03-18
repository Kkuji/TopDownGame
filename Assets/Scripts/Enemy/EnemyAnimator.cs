using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAnimator : BaseAnimator
{
    private Rigidbody2D _rigidbody;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        AssignAction();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity == Vector2.zero)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }
    }

    protected override void Die()
    {
        StartCoroutine(DieCorutine());
    }

    private IEnumerator DieCorutine()
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(_dieAnimDuration);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (_enemy != null)
        {
            UnassignAction();
        }
    }

    protected override void AssignAction()
    {
        _enemy.GetHitAction += Hit;
        _enemy.DieAction += Die;
    }

    protected override void UnassignAction()
    {
        _enemy.GetHitAction -= Hit;
        _enemy.DieAction -= Die;
    }
}