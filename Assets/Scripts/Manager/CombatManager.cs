using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;

    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;

    public int waveNumber = 1;  // Initialize wave number to 1
    public int totalEnemies = 0;
    public int points = 0;  // Store total points here

    private void OnEnable()
    {
        // Ensure spawners have a reference to the CombatManager
        foreach (EnemySpawner spawner in enemySpawners)
        {
            spawner.combatManager = this;
        }
    }

    private void Start()
    {
        // Ensure waveNumber is set to 1 at the start of the game
        waveNumber = 1;  // Explicitly reset waveNumber in case it's not initialized properly
    }

    private void FixedUpdate()
    {
        // Only increment timer if all enemies for the current wave have been killed
        if (totalEnemies == 0)
            timer += Time.deltaTime;

        if (timer >= waveInterval)
        {
            Debug.Log("Starting Wave: " + waveNumber);

            bool enemiesSpawnedThisWave = false;  // Flag to check if enemies are being spawned in this wave

            foreach (EnemySpawner spawner in enemySpawners)
            {
                // Only spawn enemies for the current wave
                if (spawner.spawnedEnemy.GetLevel() <= waveNumber && !spawner.isSpawning)
                {
                    Debug.Log("Spawning enemies at wave: " + waveNumber);
                    spawner.ResetSpawnCount();
                    totalEnemies += spawner.spawnCount;  // Update the total enemies count

                    spawner.SpawnEnemy();
                    enemiesSpawnedThisWave = true;
                }
            }

            // If enemies are spawned, move to the next wave and reset the timer
            if (enemiesSpawnedThisWave)
            {
                waveNumber++;  // Increment wave after spawning enemies
                timer = 0;  // Reset the wave timer after spawning
                Debug.Log("Wave " + waveNumber + " started, moving to next wave.");
            }
        }
    }

    // Function to increase points when an enemy is killed
    public void IncreaseKill()
    {
        totalEnemies--;  // Decrease total enemy count after each kill

        // Calculate points based on the wave number
        int pointsPerKill = 10 * waveNumber;
        points += pointsPerKill;  // Add points for the kill

        Debug.Log("Total Enemies left: " + totalEnemies);
        Debug.Log("Points earned: " + pointsPerKill + " | Total Points: " + points);  // Display points for the kill
    }
}
