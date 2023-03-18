using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerAnimator : BaseAnimator
{
    private PlayerMover _playerMover;
    private Player _player;
    private Vector2 _directionLast;
    private Vector2 _direction;

    private void Awake()
    {
        _player = GetComponent<Player>();
        AssignAction();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        _direction = _playerMover.Direction;

        if (Input.GetKeyDown(KeyCode.E))
            animator.SetTrigger("Attack");

        if (_direction.magnitude != 0)
            _directionLast = _direction;

        SetAnimatorFloats(_directionLast.x, _directionLast.y, _direction.magnitude);
    }

    private void SetAnimatorFloats(float horizontal, float vertical, float speed)
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", speed);
    }

    protected override void Die()
    {
        StartCoroutine(DieCorutine());
    }

    private IEnumerator DieCorutine()
    {
        animator.SetTrigger("Die");
        animator.SetBool("Die", true);
        yield return new WaitForSeconds(_dieAnimDuration);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (_player != null)
        {
            UnassignAction();
        }
    }

    protected override void AssignAction()
    {
        _player.GetHitAction += Hit;
        _player.DieAction += Die;
    }

    protected override void UnassignAction()
    {
        _player.GetHitAction -= Hit;
        _player.DieAction -= Die;
    }
}