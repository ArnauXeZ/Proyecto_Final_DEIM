using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject particlesPrefab; // Prefab del efecto de part�culas

    private WaveManager waveManager;

    [SerializeField] private AudioClip explosion;

    public void SetWaveManager(WaveManager manager)
    {
        waveManager = manager;
    }

    private void OnDestroy()
    {
        ControladorSonido.Instance.EjecutarSonido(explosion);
        // Instanciar el efecto de part�culas en la posici�n del enemigo
        Instantiate(particlesPrefab, transform.position, Quaternion.identity);

        if (waveManager != null)
        {
            waveManager.EnemyDied();
        }
    }
}












