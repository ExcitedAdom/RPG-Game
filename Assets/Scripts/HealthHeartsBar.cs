using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HealthHeartsBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerHealth playerHealth;

    private readonly List<HealthUI> hearts = new List<HealthUI>();

    private void OnEnable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged?.AddListener(UpdateHearts);
        }
    }

    private void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged?.RemoveListener(UpdateHearts);
        }
    }

    private void Start()
    {
        DrawHearts();
    }

    public void DrawHearts()
    {
        if (playerHealth == null)
            return;

        ClearHearts();

        int heartsToMake = Mathf.CeilToInt(playerHealth.MaxHealth / 2f);
        for (int i = 0; i < heartsToMake; i++)
        {
            CreateHeart();
        }
        UpdateHearts(playerHealth.CurrentHealth, playerHealth.MaxHealth);
    }

    public void UpdateHearts(float currentHealth, float maxHealth)
    {
        float health = currentHealth;
        for (int i = 0; i < hearts.Count; i++)
        {
            if (health >= 2f)
            {
                hearts[i].SetHeartImage(HeartStatus.Full);
                health -= 2f;
            }
            else if (health >= 1f)
            {
                hearts[i].SetHeartImage(HeartStatus.Half);
                health -= 1f;
            }
            else
            {
                hearts[i].SetHeartImage(HeartStatus.Empty);
            }
        }
    }
    
    private void CreateHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab, transform);
        HealthUI heartComponent = newHeart.GetComponent<HealthUI>();
        if (heartComponent == null)
        {
            Debug.LogError("Heart prefab must include a HealthUI component.");
            Destroy(newHeart);
            return;
        }

        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts.Clear();
    }
}
