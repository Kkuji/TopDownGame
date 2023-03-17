using UnityEngine;

public class Enemy : BaseCharacter
{
    [SerializeField] private int _damage;
    [SerializeField] private int _pushForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            Push(player.gameObject);
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