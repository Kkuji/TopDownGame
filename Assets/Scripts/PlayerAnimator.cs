using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Vector2 _direction;
    private Vector2 _directionLast;
    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _direction = _playerMover.Direction;

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
}