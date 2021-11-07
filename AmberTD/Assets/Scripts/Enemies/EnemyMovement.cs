using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform nodes;
    [SerializeField]
    private int currencyCost;

    private int nodeIndex;

    void Start()
    {
        nodeIndex = 0;
    }

    void FixedUpdate()
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
                transform.Translate(distance.normalized * speed * Time.deltaTime);
            }
        }
    }

    public void Initialize(Transform newNodes)
    {
        nodes = newNodes;
        transform.position = nodes.GetChild(0).position;
        gameObject.SetActive(true);
    }

    public void Die()
    {
        GetComponentInParent<ObjectPool>().AddToQueue(gameObject);
        EconomyScript.instance.AddCurrency(currencyCost);
        gameObject.SetActive(false);
    }
}
