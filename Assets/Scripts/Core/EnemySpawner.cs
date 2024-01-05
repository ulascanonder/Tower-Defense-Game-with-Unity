using System.Collections;
using System.Collections.Generic;
using TD.Core;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float RateOfSpawn = 1.5f;
    private GameManager gameManager;
    public GameObject enemy;
    public GameObject redEnemy;
    private float timer;
    private int enemyLimit;
    private bool redSpawned = false;
    private int redSpawnRow;
    void Start()
    {
        enemyLimit = GetComponent<LevelManager>().enemyLimit;
        gameManager = GetComponent<GameManager>();
        timer = RateOfSpawn;
        redSpawnRow = Random.Range(1, enemyLimit);
    }

    void Update()
    {

        // Spawns 1.5 enemies/sec until the enemy limit is reached
        if (enemyLimit > 0)
        {
            if (timer > 0) timer -= Time.deltaTime;
            else
            {
                timer = RateOfSpawn;
                if (enemyLimit == redSpawnRow)
                {
                    spawnRedEnemy();
                    return;
                }
                spawnEnemy();
            }
        }

    }

    private void spawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        enemyLimit--;
        gameManager.scoreLimit++;
    }
    private void spawnRedEnemy()
    {
        Instantiate(redEnemy, transform.position, transform.rotation);
        enemyLimit--;
        gameManager.scoreLimit++;
    }


}
