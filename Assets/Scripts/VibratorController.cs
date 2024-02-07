using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VibrationController : MonoBehaviour
{
    public float vibrationDuration = 0.1f; // Duraci�n de la vibraci�n en segundos
    private Gamepad gamepad;
    private bool vibrationStarted = false;

    void Start()
    {
        // Obtener el Gamepad actual
        gamepad = Gamepad.current;
    }

    void Update()
    {
        // Comprobar si se debe iniciar la vibraci�n
        if (!vibrationStarted && gamepad != null)
        {
            // Iniciar la vibraci�n
            vibrationStarted = true;
            gamepad.SetMotorSpeeds(0.5f, 0.5f); // Establecer la intensidad de la vibraci�n
            Invoke("StopVibration", vibrationDuration); // Detener la vibraci�n despu�s de la duraci�n especificada
        }
    }

    void StopVibration()
    {
        // Detener la vibraci�n
        gamepad.SetMotorSpeeds(0, 0);
        vibrationStarted = false;
    }
}

