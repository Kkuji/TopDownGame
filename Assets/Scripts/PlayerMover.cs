using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;

    public Vector2 Direction => _direction;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction.normalized * _speed * Time.deltaTime;
    }
}