using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [Range(1, 20)]
    public int enemyCount;
    [Range(1, 100)]
    public float Cd;
    [Range(1, 100)]
    public int Minlvl = 1;
    [Range(1, 100)]
    public int Maxlvl = 5;
    [Range(0.1f, 5f)]
    public float dispersion;
    private float heat;
    private int activeEnemies = 0;
    public GameObject prefabToSpawn;

    public Action onEnemyKilled;

    Vector2[,] spawnPositions;
    int spawnCounter = 0;
    int maxSpawns = 0;

    private void Start()
    {
        heat = Cd;
        spawnPositions = new Vector2[3, 3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                spawnPositions[i, j] = new Vector2(i * dispersion, j * dispersion);
        maxSpawns = spawnPositions.GetLength(0) * spawnPositions.GetLength(1);
    }

    void Update()
    {
        if (activeEnemies == 0)
        {
            heat -= Time.deltaTime;
        }
        if (heat <= 0)
        {
            Spawn(prefabToSpawn);
            heat = Cd;
        }
    }

    void Spawn(GameObject prefabToSpawn)
    {
        
        for (int i = 0; i < enemyCount; i++)
        {
            if (spawnCounter >= maxSpawns)
            {
                spawnCounter = 0;
            }
            Vector3 spawnPosition = spawnPositions[spawnCounter / spawnPositions.GetLength(1), spawnCounter % spawnPositions.GetLength(1)];
            int randomLevel = UnityEngine.Random.Range(Minlvl, Maxlvl);
            GameObject spawnedEnemy = Instantiate(prefabToSpawn, transform.position + spawnPosition, transform.rotation);
            spawnedEnemy.GetComponent<Enemy>().enemyLvl = randomLevel;
            spawnedEnemy.GetComponent<Enemy>().spawner = this;
            activeEnemies++;
            spawnCounter++;
        }
    }

    public void DecreaseActiveEnemies()
    {
        activeEnemies--;
    }
}