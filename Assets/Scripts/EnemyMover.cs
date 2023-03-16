using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _distanceWhenChase;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
    private float _currentDistance;
    private Vector2 _direction;
    private Player _player;

    private void Start()
    {
        _player = _target.gameObject.GetComponent<Player>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _currentDistance = (_target.position - transform.position).magnitude;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_player.currentHealth > 0)
        {
            if (_currentDistance < _distanceWhenChase)
            {
                _direction = (_target.position - transform.position).normalized;
                _rigidbody.AddForce(_direction.normalized * _speed * Time.deltaTime);
                _renderer.flipX = _target.position.x < transform.position.x;
            }
            else
            {
                _rigidbody.velocity = Vector2.zero;
            }
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}