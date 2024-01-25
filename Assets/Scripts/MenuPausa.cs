using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;


    void Update()
    {
        // Detecta si se presiona la tecla ESC o el bot�n "Options" en el controlador de PS4
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Options"))
        {
            // Llama a la funci�n que maneja la pausa
            ManejarPausa();
        }
    }

    void ManejarPausa()
    {
        // Si el men� de pausa est� activo, lo desactiva y reanuda el tiempo
        if (menuPausa.activeSelf)
        {
            menuPausa.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            // Si el men� de pausa est� inactivo, lo activa y pausa el tiempo
            menuPausa.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
