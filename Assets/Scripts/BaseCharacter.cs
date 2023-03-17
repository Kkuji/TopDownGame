using System;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    [SerializeField] private int _health;

    [HideInInspector] public int currentHealth;

    public event Action GetHitAction;
    public event Action DieAction;

    private void Start()
    {
        currentHealth = _health;
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