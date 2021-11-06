using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform nodes;

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
            Vector2 distance = nodes.GetChild(nodeIndex).transform.position - transform.position;
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
}
