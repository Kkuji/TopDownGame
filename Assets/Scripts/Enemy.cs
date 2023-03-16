using UnityEngine;
using System;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private int _pushForce;

    private int _currentHealth;

    public event Action GetHitAction;

    public event Action DieAction;

    private void Start()
    {
        _currentHealth = _health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            //Push(player.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out PlayerSword playerSword))
        {
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            DieAction?.Invoke();
        }
        else
        {
            GetHitAction?.Invoke();
        }
    }

    private void Push(GameObject objectToPush)
    {
        Vector2 direction = (objectToPush.transform.position - transform.position).normalized;
        Vector2 push = direction * _pushForce;
        Rigidbody2D rbObectToPush = objectToPush.GetComponent<Rigidbody2D>();
        rbObectToPush.AddForce(push);
    }
}