using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameOver : MonoBehaviour
{
    private Gamepad gamepad;
    void Start()
    {
        gamepad.SetMotorSpeeds(0, 0);
    }

    
}
