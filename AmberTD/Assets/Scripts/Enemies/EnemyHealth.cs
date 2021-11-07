using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthScript
{
    protected override void Die()
    {
        GetComponent<EnemyMovement>().Die();
    }
}
