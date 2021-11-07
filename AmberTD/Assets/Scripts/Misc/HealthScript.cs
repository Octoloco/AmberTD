using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    private float health;

    void Start()
    {
        health = maxHealth;
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

    public void ReduceHealth(float ammount)
    {
        health -= ammount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void AddHealth(float ammount)
    {
        health += ammount;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    protected virtual void Die()
    {
        //Add custom death behaviour
    }
}
