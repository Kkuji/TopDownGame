using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speed;

    private bool _isAttacking = false;
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private Player _player;

    public Vector2 Direction => _direction;

    private void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_player.currentHealth > 0)
        {
            if (!_isAttacking && _rigidbody.velocity.magnitude < _maxSpeed)
            {
                _rigidbody.AddForce(_direction.normalized * _speed * Time.deltaTime);
            }

            if (_direction == Vector2.zero || _isAttacking)
            {
                _rigidbody.velocity = Vector2.zero;
            }
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    public void LockMovement()
    {
        _isAttacking = true;
    }

    public void UnLockMovement()
    {
        _isAttacking = false;
    }
}