using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private TextMeshProUGUI healthText;

    private float health;

    void Start()
    {
        health = maxHealth;
        UpdateCurrency();
    }

    public void ResetHealth()
    {
        health = maxHealth;
        UpdateCurrency();
    }

    public void ReduceHealth(float ammount)
    {
        health -= ammount;

        if (health <= 0)
        {
            Die();
        }
        UpdateCurrency();
    }

    public void AddHealth(float ammount)
    {
        health += ammount;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateCurrency();
    }

    public float GetCurrentHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    protected virtual void Die()
    {
        //Add custom death behaviour
    }

    private void UpdateCurrency()
    {
        if (healthText != null)
        {
            healthText.text = health.ToString();
        }
    }
}
