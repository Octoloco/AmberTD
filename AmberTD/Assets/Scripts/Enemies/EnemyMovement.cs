using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private enum EnemyType { Normal, Slow, Area };
    [SerializeField]
    private EnemyType enemyType = EnemyType.Normal;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float slowDuration;
    [SerializeField]
    private Transform nodes;
    [SerializeField]
    private CurrencyScriptableObject currencyData;
    [SerializeField]
    private DamageScriptableObject damageData;

    private bool slowed;
    private float actualSpeed;
    private int nodeIndex;

    void Start()
    {
        nodeIndex = 0;
        actualSpeed = speed;
    }

    void FixedUpdate()
    {
        if (!GameManagerScript.instance.IsGamePaused())
        {
            if (nodeIndex < nodes.childCount)
            {
                //Measure the distance between enemy and next node
                Vector2 distance = nodes.GetChild(nodeIndex).position - transform.position;
                if (distance.magnitude < 0.1f)
                {
                    // if the enemy arrived at node, go to next node
                    nodeIndex++;
                }
                else
                {
                    // if the enemy did not arrive yet, continue moving
                    transform.Translate(distance.normalized * actualSpeed * Time.deltaTime);
                }
            }
            else
            {
                //The enemy reached the last node (damages player)
                if (enemyType == EnemyType.Normal)
                {
                    PlayerHealth.instance.ReduceHealth(damageData.Enemy1Damage);
                }
                else if (enemyType == EnemyType.Slow)
                {
                    PlayerHealth.instance.ReduceHealth(damageData.Enemy2Damage);
                }
                else if (enemyType == EnemyType.Area)
                {
                    PlayerHealth.instance.ReduceHealth(damageData.Enemy3Damage);
                }
                Die();
            }
        }
    }

    public void Initialize(Transform newNodes)
    {
        nodes = newNodes;
        slowed = false;
        CancelInvoke();
        actualSpeed = speed;
        transform.position = nodes.GetChild(0).position;
        nodeIndex = 0;
        GetComponent<EnemyHealth>().ResetHealth();
        gameObject.SetActive(true);
    }

    public void Die()
    {
        GetComponentInParent<ObjectPool>().AddToQueue(gameObject);
        if (nodeIndex < nodes.childCount)
        {
            if (enemyType == EnemyType.Normal)
            {
                EconomyScript.instance.AddCurrency(currencyData.Enemy1Reward);
            }
            else if (enemyType == EnemyType.Slow)
            {
                EconomyScript.instance.AddCurrency(currencyData.Enemy2Reward);
            }
            else if (enemyType == EnemyType.Area)
            {
                EconomyScript.instance.AddCurrency(currencyData.Enemy3Reward);
            }
        }
        gameObject.SetActive(false);
    }

    public void SlowEnemy()
    {
        StartCoroutine(SlowCooldown());
    }

    IEnumerator SlowCooldown()
    {
        actualSpeed = speed / 2;
        yield return new WaitForSeconds(slowDuration);
        actualSpeed = speed;
    }
}
