using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;

    void Update()
    {
        // Detecta si se presiona la tecla ESC o el botón "Options" en el controlador de PS4
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("joystick button 9"))
        {
            ToggleMenuPausa();
        }
    }

    public void ToggleMenuPausa()
    {
        // Activa o desactiva el menú de pausa
        menuPausa.SetActive(!menuPausa.activeSelf);

        // Pausa o reanuda el tiempo del juego
        Time.timeScale = (menuPausa.activeSelf) ? 0f : 1f;
    }
}
