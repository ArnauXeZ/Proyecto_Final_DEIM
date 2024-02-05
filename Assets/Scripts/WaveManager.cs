using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab del enemigo que quieres generar.
    public Transform spawnPoint;    // Punto de generación de los enemigos.
    public int numberOfEnemies = 10; // Número de enemigos por oleada.
    public float timeBetweenWaves = 5f; // Tiempo entre oleadas.

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            // Puedes ajustar la posición y rotación según tus necesidades.
        }
    }
}
