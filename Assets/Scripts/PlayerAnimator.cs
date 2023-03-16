using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private float _dieAnimDuration;

    private PlayerMover _playerMover;
    private Animator _animator;
    private Player _player;
    private Vector2 _directionLast;
    private Vector2 _direction;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();

        _player.GetHitAction += Hit;
        _player.DieAction += Die;
    }

    private void Update()
    {
        _direction = _playerMover.Direction;

        if (Input.GetKeyDown(KeyCode.E))
            _animator.SetTrigger("Attack");

        if (_direction.magnitude != 0)
            _directionLast = _direction;

        SetAnimatorFloats(_directionLast.x, _directionLast.y, _direction.magnitude);
    }

    private void SetAnimatorFloats(float horizontal, float vertical, float speed)
    {
        _animator.SetFloat("Horizontal", horizontal);
        _animator.SetFloat("Vertical", vertical);
        _animator.SetFloat("Speed", speed);
    }

    private void Hit()
    {
        _animator.SetTrigger("Hit");
    }

    private void Die()
    {
        StartCoroutine(DieCorutine());
    }

    private IEnumerator DieCorutine()
    {
        _animator.SetTrigger("Die");
        _animator.SetBool("Die", true);
        yield return new WaitForSeconds(_dieAnimDuration);
        gameObject.SetActive(false);
    }
}