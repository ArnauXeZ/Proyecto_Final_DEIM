using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public BackgroundMusic backgroundMusic;
    public void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        // Detecta si se presiona la tecla ESC o el botón "Options" en el controlador de PS4
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Options"))
        {
            // Llama a la función que maneja la pausa
            ToggleMenuPausa();
        }
    }

    public void ToggleMenuPausa()
    {
        bool menuActivo = !menuPausa.activeSelf;
        menuPausa.SetActive(menuActivo);

        // Pausar o reanudar la música según el estado del menú
        if (menuActivo)
        {
            // Pausar la música cuando se activa el menú de pausa
            backgroundMusic.PausarMusica();
            Time.timeScale = 0f; // Pausar el juego
        }
        else
        {
            // Reanudar la música cuando se desactiva el menú de pausa
            backgroundMusic.ReanudarMusica();
            Time.timeScale = 1f; // Reanudar el juego
        }
    }
}
