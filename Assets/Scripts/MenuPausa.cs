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
        // Detecta si se presiona la tecla ESC o el bot�n "Options" en el controlador de PS4
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Options"))
        {
            // Llama a la funci�n que maneja la pausa
            ToggleMenuPausa();
        }
    }

    public void ToggleMenuPausa()
    {
        bool menuActivo = !menuPausa.activeSelf;
        menuPausa.SetActive(menuActivo);

        // Pausar o reanudar la m�sica seg�n el estado del men�
        if (menuActivo)
        {
            // Pausar la m�sica cuando se activa el men� de pausa
            backgroundMusic.PausarMusica();
            Time.timeScale = 0f; // Pausar el juego
        }
        else
        {
            // Reanudar la m�sica cuando se desactiva el men� de pausa
            backgroundMusic.ReanudarMusica();
            Time.timeScale = 1f; // Reanudar el juego
        }
    }
}
