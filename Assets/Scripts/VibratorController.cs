using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VibrationController : MonoBehaviour
{
    public float vibrationDuration = 0.1f; // Duración de la vibración en segundos
    private Gamepad gamepad;
    private bool vibrationStarted = false;

    void Start()
    {
        // Obtener el Gamepad actual
        gamepad = Gamepad.current;
    }

    void Update()
    {
        // Comprobar si se debe iniciar la vibración
        if (!vibrationStarted && gamepad != null)
        {
            // Iniciar la vibración
            vibrationStarted = true;
            gamepad.SetMotorSpeeds(0.5f, 0.5f); // Establecer la intensidad de la vibración
            Invoke("StopVibration", vibrationDuration); // Detener la vibración después de la duración especificada
        }
    }

    void StopVibration()
    {
        // Detener la vibración
        gamepad.SetMotorSpeeds(0, 0);
        vibrationStarted = false;
    }
}

