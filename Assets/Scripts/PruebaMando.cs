using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PruebaMando : MonoBehaviour
{
    private Gamepad gamepad;


    private float vibrationDuration = 0.1f;


    private void Start()
    {
        StartCoroutine("Vibracion");
    }

    IEnumerator Vibracion()
    {
        if (Gamepad.current != null)
        {
            gamepad = Gamepad.current;
            gamepad.SetMotorSpeeds(1f, 1f);
            yield return new WaitForSeconds(vibrationDuration);
            gamepad.SetMotorSpeeds(0, 0);
            
        }
    }
}
