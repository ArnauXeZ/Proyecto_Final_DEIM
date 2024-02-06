using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public int startingNumberOfEnemies = 10; // Número inicial de enemigos por fila.
    public int incrementPerWave = 2; // Incremento de filas por oleada.
    public float rowSpacing = 2f; // Espaciado entre las filas de enemigos.
    public float enemySpacing = 2f; // Espaciado entre los enemigos en una fila.
    public float timeBetweenWaves = 5f;
    private int currentNumberOfRows; // Número actual de filas de enemigos por oleada.
    private int enemiesRemaining;

    private void Start()
    {
        currentNumberOfRows = 1;
        StartWave();
    }

    void StartWave()
    {
        enemiesRemaining = currentNumberOfRows * startingNumberOfEnemies;
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        float zOffset = (currentNumberOfRows - 1) * rowSpacing / 2f; // Offset inicial en el eje Z

        for (int row = 0; row < currentNumberOfRows; row++)
        {
            float xOffset = ((startingNumberOfEnemies - 1) * enemySpacing) / 2; // Espaciado horizontal inicial
            Vector3 rowStartPosition = new Vector3(spawnPoint.position.x - xOffset, spawnPoint.position.y, spawnPoint.position.z + zOffset);

            for (int i = 0; i < startingNumberOfEnemies; i++)
            {
                Vector3 spawnPosition = rowStartPosition + new Vector3(i * enemySpacing, 0f, 0f);
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, spawnPoint.rotation);
                enemy.GetComponent<Enemy>().SetWaveManager(this);
            }

            zOffset -= rowSpacing; // Decrementamos el offset en el eje Z para la próxima fila.
        }

        yield return new WaitUntil(() => enemiesRemaining == 0);

        yield return new WaitForSeconds(timeBetweenWaves);

        currentNumberOfRows += incrementPerWave; // Incrementamos el número de filas por oleada.

        StartWave();
    }

    public void EnemyDied()
    {
        enemiesRemaining--;
    }
}








