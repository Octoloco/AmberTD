using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform nodes;
    [SerializeField]
    private ObjectPool poolEnemy1;
    [SerializeField]
    private ObjectPool poolEnemy2;
    [SerializeField]
    private ObjectPool poolEnemy3;
    [SerializeField]
    private string[] waves;
    [SerializeField]
    private float timeToSpawn;

    private float spawnTimer;
    private int currentWave;
    private int currentEnemy;

    void Start()
    {
        currentWave = 0;
        spawnTimer = 0;
    }

    void Update()
    {
        if (currentWave < waves.Length)
        {
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            else
            {
                spawnTimer = timeToSpawn;
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        if (waves.Length > 0)
        {
            if (currentEnemy < waves[currentWave].Length)
            {
                if (waves[currentWave][currentEnemy] == '1')
                {
                    GameObject newEnemy = poolEnemy1.GetObjectFromPool();
                    newEnemy.GetComponent<EnemyMovement>().Initialize(nodes);
                }
                else if (waves[currentWave][currentEnemy] == '2')
                {
                    GameObject newEnemy = poolEnemy2.GetObjectFromPool();
                    newEnemy.GetComponent<EnemyMovement>().Initialize(nodes);
                }
                else if (waves[currentWave][currentEnemy] == '3')
                {
                    GameObject newEnemy = poolEnemy3.GetObjectFromPool();
                    newEnemy.GetComponent<EnemyMovement>().Initialize(nodes);
                }
                currentEnemy++;
            }
            else
            {
                currentEnemy = 0;
                currentWave++;
            }
        }
    }
}
