using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private HurtBox hurtBox;    
    [SerializeField] private float maxHealth = 100f;
    public float MaxHealth => maxHealth;
    private float currentHealth = 0;
    public float CurrentHealth => currentHealth;

    public event Action<float> HealthChangedEvent;
    protected void InvokeHealthChanged()
    {
        HealthChangedEvent?.Invoke(currentHealth);
    }
    private void Awake()
    {
        currentHealth = maxHealth;
        TryGetComponent(out hurtBox);
        hurtBox.TakeHitEvent += OnTakeHit;
    }
    public void OnTakeHit(float damage)
    {
        TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        InvokeHealthChanged();
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void Heal(float heal)
    {
        currentHealth += heal;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        InvokeHealthChanged();
    }
    private void Die()
    {
        Destroy(gameObject);
    }

}
