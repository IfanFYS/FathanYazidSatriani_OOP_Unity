using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0f;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 1;
    public int totalEnemies = 0;
    public int remainingEnemies = 0;

    private bool waveInProgress = false;

    private void Update()
    {
        if (!waveInProgress)
        {
            timer += Time.deltaTime;

            if (timer >= waveInterval)
            {
                StartNewWave();
                timer = 0f;
            }
        }
    }

    private void StartNewWave()
    {
        waveInProgress = true;
        Debug.Log($"Wave {waveNumber} started!");

        foreach (var spawner in enemySpawners)
        {
            spawner.spawnCount = spawner.defaultSpawnCount + (waveNumber - 1) * spawner.spawnCountMultiplier;
            spawner.StartSpawning();
            totalEnemies += spawner.spawnCount;
        }

        remainingEnemies = totalEnemies;
    }

    public void EnemyDefeated()
    {
        remainingEnemies--;
        Debug.Log($"Enemy defeated. Remaining: {remainingEnemies}");

        if (remainingEnemies <= 0)
        {
            Debug.Log($"Wave {waveNumber} completed!");
            waveInProgress = false;
            waveNumber++;

            foreach (var spawner in enemySpawners)
            {
                spawner.StopSpawning();
            }

            totalEnemies = 0;
        }
    }
}

