using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Variables públicas para configurar en el Editor de Unity
    public GameObject enemyPrefab; // Prefab del enemigo
    public GameObject powerUpPrefab; // Prefab del Power Up
    public Transform spawnPoint; // Punto de generación de los enemigos y Power Ups
    public int startingNumberOfEnemies = 10; // Número inicial de enemigos por fila
    public int incrementPerWave = 2; // Incremento de filas por oleada
    public float rowSpacing = 2f; // Espaciado entre las filas de enemigos
    public float enemySpacing = 2f; // Espaciado entre los enemigos en una fila
    public float timeBetweenWaves = 5f; // Tiempo entre cada oleada
    public float powerUpChance = 0.2f; // Probabilidad de que aparezca un Power Up
    private int currentNumberOfRows; // Número actual de filas de enemigos por oleada
    [SerializeField] private int enemiesRemaining; // Número de enemigos restantes en la oleada actual
    [SerializeField] private int powerUpsRemaining; // Número de Power Ups restantes en la oleada actual

    // Método que se llama al inicio del juego
    private void Start()
    {
        // Configurar el número inicial de filas y comenzar la primera oleada
        currentNumberOfRows = 1;
        StartWave();
    }

    // Método para iniciar una nueva oleada
    void StartWave()
    {
        // Inicializar el número de enemigos y Power Ups restantes
        enemiesRemaining = currentNumberOfRows * startingNumberOfEnemies;
        Debug.Log("Start enemies" + enemiesRemaining);
        powerUpsRemaining = Random.value <= powerUpChance ? currentNumberOfRows : 0; // Determinar si aparece un Power Up
        StartCoroutine(SpawnWave()); // Iniciar la corutina para generar la oleada
    }

    // Corutina para generar la oleada de enemigos y Power Ups
    IEnumerator SpawnWave()
    {
        // Calcular el desplazamiento inicial en el eje Z para posicionar las filas
        float zOffset = (currentNumberOfRows - 1) * rowSpacing / 2f;

        // Recorrer cada fila de enemigos
        for (int row = 0; row < currentNumberOfRows; row++)
        {
            // Calcular el desplazamiento inicial en el eje X para posicionar los enemigos
            float xOffset = ((startingNumberOfEnemies - 1) * enemySpacing) / 2;
            Vector3 rowStartPosition = new Vector3(spawnPoint.position.x - xOffset, spawnPoint.position.y, spawnPoint.position.z + zOffset);

            // Generar cada enemigo en la fila
            for (int i = 0; i < startingNumberOfEnemies; i++)
            {
                Vector3 spawnPosition = rowStartPosition + new Vector3(i * enemySpacing, 0f, 0f);

                // Generar un Power Up en la última posición si quedan disponibles
                if (powerUpsRemaining > 0 && i == startingNumberOfEnemies - 1)
                {
                    Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
                    enemiesRemaining--;
                    Debug.Log("power up enemies" + enemiesRemaining);
                    //powerUpsRemaining--;
                }
                else // Generar un enemigo en la posición actual
                {
                    GameObject enemy = Instantiate(enemyPrefab, spawnPosition, spawnPoint.rotation);
                    enemy.GetComponent<Enemy>().SetWaveManager(this);
                }
            }

            // Calcular el desplazamiento para la próxima fila
            zOffset -= rowSpacing;
        }

        // Esperar hasta que se destruyan todos los enemigos y Power Ups
        yield return new WaitUntil(() => enemiesRemaining == 0);
        yield return new WaitUntil(() => powerUpsRemaining == 0);

        // Esperar un tiempo antes de iniciar la siguiente oleada
        yield return new WaitForSeconds(timeBetweenWaves);

        // Incrementar el número de filas para la próxima oleada y comenzarla
        currentNumberOfRows += incrementPerWave;
        StartWave();
    }

    // Método llamado cuando un enemigo es destruido
    public void EnemyDied()
    {
        enemiesRemaining--; // Reducir el contador de enemigos restantes
    }

    // Método llamado cuando se recoge un Power Up
    public void PowerUpCollected()
    {
        powerUpsRemaining--; // Reducir el contador de Power Ups restantes
        Debug.Log("power up destroy");
    }
}














