using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Vector2 _direction;
    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _direction = _playerMover.Direction;

        _animator.SetFloat("Horizontal", _direction.x);
        _animator.SetFloat("Vertical", _direction.y);
        _animator.SetFloat("Speed", _direction.magnitude);
    }
}