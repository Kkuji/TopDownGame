using UnityEngine;
using System;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;

    [HideInInspector] public int currentHealth;

    public event Action GetHitAction;

    public event Action DieAction;

    private void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            DieAction?.Invoke();
        }
        else
        {
            GetHitAction?.Invoke();
        }
    }
}