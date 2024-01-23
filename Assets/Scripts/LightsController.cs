using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsController : MonoBehaviour
{
    public GameObject lights;

    // Mantén un estado para las luces
    private bool lightsActive = true;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Cambia el estado de las luces al contrario del estado actual
            lightsActive = !lightsActive;

            // Activa o desactiva las luces según el nuevo estado
            lights.SetActive(lightsActive);
        }
        // Verifica si se presiona el botón R1 del mando de PS4
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))  // Puedes necesitar ajustar el número del botón según tu configuración
        {
            // Cambia el estado de las luces al contrario del estado actual
            lightsActive = !lightsActive;

            // Activa o desactiva las luces según el nuevo estado
            lights.SetActive(lightsActive);
        }
    }
}
