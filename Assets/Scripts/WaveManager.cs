using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public Transform spawnPoint;
    public int startingNumberOfEnemies = 10;
    public int incrementPerWave = 2;
    public float rowSpacing = 2f;
    public float enemySpacing = 2f;
    public float timeBetweenWaves = 5f;
    public float powerUpChance = 0.2f;
    private int currentNumberOfRows;
    private int enemiesRemaining;
    private int powerUpsRemaining; // Nuevo: rastreo de Power Ups restantes

    private void Start()
    {
        currentNumberOfRows = 1;
        StartWave();
    }

    void StartWave()
    {
        Debug.Log("Starting new wave...");
        enemiesRemaining = currentNumberOfRows * startingNumberOfEnemies;
        powerUpsRemaining = Random.value <= powerUpChance ? 1 : 0;
        StartCoroutine(SpawnWave());
    }



    IEnumerator SpawnWave()
    {
        Debug.Log("Spawning wave...");

        float zOffset = (currentNumberOfRows - 1) * rowSpacing / 2f;

        for (int row = 0; row < currentNumberOfRows; row++)
        {
            Debug.Log("Spawning enemies in row " + (row + 1));

            float xOffset = ((startingNumberOfEnemies - 1) * enemySpacing) / 2;
            Vector3 rowStartPosition = new Vector3(spawnPoint.position.x - xOffset, spawnPoint.position.y, spawnPoint.position.z + zOffset);

            for (int i = 0; i < startingNumberOfEnemies; i++)
            {
                Vector3 spawnPosition = rowStartPosition + new Vector3(i * enemySpacing, 0f, 0f);

                if (powerUpsRemaining > 0 && i == startingNumberOfEnemies - 1)
                {
                    Debug.Log("Spawning power up at position " + spawnPosition);
                    Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
                    powerUpsRemaining--;
                }
                else
                {
                    Debug.Log("Spawning enemy at position " + spawnPosition);
                    GameObject enemy = Instantiate(enemyPrefab, spawnPosition, spawnPoint.rotation);
                    enemy.GetComponent<Enemy>().SetWaveManager(this);
                }
            }

            zOffset -= rowSpacing;
        }

        yield return new WaitUntil(() => enemiesRemaining == 0);

        yield return new WaitUntil(() => powerUpsRemaining == 0);

        yield return new WaitForSeconds(timeBetweenWaves);

        currentNumberOfRows += incrementPerWave;
        StartWave();
    }


    public void EnemyDied()
    {
        enemiesRemaining--; // Reducir el contador de enemigos restantes
    }

    // Nuevo: método para reducir el contador de Power Ups restantes
    public void PowerUpCollected()
    {
        powerUpsRemaining--;
    }
}













