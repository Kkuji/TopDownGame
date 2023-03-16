using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    [SerializeField] private int _pushForce;
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Push(enemy.gameObject);
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