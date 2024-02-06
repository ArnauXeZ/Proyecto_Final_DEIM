using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject particlesPrefab; // Prefab del efecto de part�culas
    public AudioSource playerAudioSource; // Referencia al componente AudioSource del jugador

    private WaveManager waveManager;

    public void SetWaveManager(WaveManager manager)
    {
        waveManager = manager;
    }

    private void OnDestroy()
    {
        // Reproducir el sonido del jugador si est� asignado
        if (playerAudioSource != null)
        {
            playerAudioSource.Play();
        }

        // Instanciar el efecto de part�culas en la posici�n del enemigo
        Instantiate(particlesPrefab, transform.position, Quaternion.identity);

        if (waveManager != null)
        {
            waveManager.EnemyDied();
        }
    }
}












