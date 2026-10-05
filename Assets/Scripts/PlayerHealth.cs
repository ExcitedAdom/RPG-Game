using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth, currentHealth;
    [SerializeField] private float knockbackStrength;
    [SerializeField] private float knockbackDuration;
    public UnityEvent<float, float> OnHealthChanged = new UnityEvent<float, float>();
    public UnityEvent OnDeath = new UnityEvent();
    public bool IsKnockedBack { get; private set; }
    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
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

    // public void Heal(float amount)
    // {
    //     currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    //     OnHealthChanged?.Invoke(currentHealth, maxHealth);
    // }

    // private void Die()
    // {
    //     OnDeath?.Invoke();
    //     GameManager.Instance.GameOver();
    // }

    public void ApplyKnockBack(Vector2 sourcePosition)
    {
        if (rb == null)
        return;

        Vector2 knockbackDirection = ((Vector2)transform.position - sourcePosition).normalized;
        rb.linearVelocity = Vector2.zero; // Don't move ur ahh while being knocked back bitch
        rb.AddForce(knockbackDirection * knockbackStrength, ForceMode2D.Impulse);

        IsKnockedBack = true;
        Invoke(nameof(ClearKnockback), knockbackDuration);
    }

    private void ClearKnockback()
    {
        IsKnockedBack = false;
    }
}