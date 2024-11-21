using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject spawnedEnemy;

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;
    private int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 1; // Default count for the first wave
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public bool isSpawning = false;

    private float spawnTimer = 0f;

    public void StartSpawning()
    {
        isSpawning = true;
        spawnTimer = spawnInterval;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    private void Update()
    {
        if (isSpawning)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0f)
            {
                SpawnEnemies();
                spawnTimer = spawnInterval;
            }
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
        }
    }
}



