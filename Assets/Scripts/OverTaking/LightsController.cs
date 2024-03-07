using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsController : MonoBehaviour
{
    public GameObject lights;

    // Mant�n un estado para las luces
    private bool lightsActive = true;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) || Input.GetButtonDown("Lights"))
        {
            // Cambia el estado de las luces al contrario del estado actual
            lightsActive = !lightsActive;

            // Activa o desactiva las luces seg�n el nuevo estado
            lights.SetActive(lightsActive);
        }
        
        
    }
}
