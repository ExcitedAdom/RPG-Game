// using UnityEngine;
// using UnityEngine.UI;
// using System.Collections;
// using UnityEngine.Events;

// public class PlayerHealth : MonoBehaviour
// {
//     [SerializeField] private int maxHealth = 100;
//     [SerializeField] private Slider healthSlider;
//     private int currentHealth;

//     public UnityEvent<int, int> OnHealthChanged;
//     public UnityEvent OnDeath;

//     void Start()
//     {
//         currentHealth = maxHealth;
//         OnHealthChanged?.Invoke(currentHealth, maxHealth);
//         UpdateHealthUI();
//     }

//     public void TakeDamage(int amount)
//     {
//         currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
//         OnHealthChanged?.Invoke(currentHealth, maxHealth);
//         UpdateHealthUI();

//         if (currentHealth <= 0)
//         {
//             Die();
//         }   
//     }

//     public void Heal(int amount)
//     {
//         currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
//         OnHealthChanged?.Invoke(currentHealth, maxHealth);
//         UpdateHealthUI();
//     }

//     private void UpdateHealthUI()
//     {
//         healthSlider.value = (float)currentHealth / maxHealth;
//     }

//     private void Die()
//     {
//         OnDeath?.Invoke();
//         GameManager.Instance.GameOver();
//     }
// }