using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAudio : MonoBehaviour
{
    public AudioSource musicaFondo;

    void Start()
    {
        // Llama a la funci�n que inicia la m�sica despu�s de 15 segundos
        Invoke("IniciarMusicaFondo", 15f);
    }

    void IniciarMusicaFondo()
    {
        // Aseg�rate de que la m�sica de fondo no est� ya reproduci�ndose
        if (!musicaFondo.isPlaying)
        {
            // Inicia la reproducci�n de la m�sica de fondo
            musicaFondo.Play();
        }
    }
}
