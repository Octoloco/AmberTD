using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    private TextMeshProUGUI waveTimeText;
    [SerializeField]
    private string[] waves;
    [SerializeField]
    private float timeToSpawn;
    [SerializeField]
    private float timeBetweenWaves;

    private float spawnTimer;
    private int currentWave;
    private int currentEnemy;
    private float waveTimer;

    void Start()
    {
        waveTimer = timeBetweenWaves;
        currentWave = 0;
        spawnTimer = 0;
    }

    void Update()
    {
        if (!GameManagerScript.instance.IsGamePaused())
        {
            if (currentWave < waves.Length)
            {
                if (waveTimer > 0)
                {
                    waveTimer -= Time.deltaTime;
                }

                if (waveTimer < 0)
                {
                    waveTimer = 0;
                }
                waveTimeText.text = waveTimer.ToString("F2");
            }

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
            if (currentWave < waves.Length)
            {
                if (waveTimer <= 0)
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
                        waveTimer = timeBetweenWaves;
                        currentEnemy = 0;
                        currentWave++;
                    }
                }
            }
            else
            {
                bool enemiesStillAlive = false;
                for (int i = 0; i < poolEnemy1.transform.childCount; i++)
                {
                    if (poolEnemy1.transform.GetChild(i).gameObject.activeInHierarchy)
                    {
                        enemiesStillAlive = true;
                    }
                }

                for (int i = 0; i < poolEnemy2.transform.childCount; i++)
                {
                    if (poolEnemy2.transform.GetChild(i).gameObject.activeInHierarchy)
                    {
                        enemiesStillAlive = true;
                    }
                }

                for (int i = 0; i < poolEnemy3.transform.childCount; i++)
                {
                    if (poolEnemy3.transform.GetChild(i).gameObject.activeInHierarchy)
                    {
                        enemiesStillAlive = true;
                    }
                }

                if (!enemiesStillAlive)
                {
                    CameraCanvasManager.instance.ShowWinPanel();
                }
            }
        }
    }
}
