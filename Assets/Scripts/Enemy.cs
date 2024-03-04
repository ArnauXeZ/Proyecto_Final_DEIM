using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            ControladorSonido.Instance.EjecutarSonido(explosion);
            // Instanciar el efecto de part�culas en la posici�n del enemigo
            Instantiate(particlesPrefab, transform.position, Quaternion.identity);

            if (waveManager != null)
            {
                waveManager.EnemyDied();
            }

            // Llamar al script de control de vibraci�n
            FindObjectOfType<PruebaMando>().StartCoroutine("Vibracion");
        }    
        
    }

}












