using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth, currentHealth;
    public UnityEvent<float, float> OnHealthChanged = new UnityEvent<float, float>();
    public UnityEvent OnDeath = new UnityEvent();

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        // if (currentHealth <= 0)
        // {
        //     Die();
        // }   
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    // private void Die()
    // {
    //     OnDeath?.Invoke();
    //     GameManager.Instance.GameOver();
    // }
}