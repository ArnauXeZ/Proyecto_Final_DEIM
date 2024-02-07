using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    public GameObject particlesPrefab; // Prefab del efecto de part�culas

    private WaveManager waveManager;

    [SerializeField] private AudioClip explosion;

    // Vibraci�n del mando
    private Gamepad gamepad;
    private bool vibrationStarted = false;
    private float vibrationDuration = 0.009f;
    private float vibrationIntensity = 0.3f;

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
        
        // Hacer vibrar el mando
        if (Gamepad.current != null)
        {
            if (!vibrationStarted)
            {
                vibrationStarted = true;
                gamepad = Gamepad.current;
                gamepad.SetMotorSpeeds(vibrationIntensity, vibrationIntensity);
                Invoke("StopVibration", vibrationDuration);
            }
        }

    }

    private void StopVibration()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0, 0);
            vibrationStarted = false;
        }
    }

}












