using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAudio : MonoBehaviour
{
    public AudioSource musicaFondo;

    void Start()
    {
        // Llama a la función que inicia la música después de 15 segundos
        Invoke("IniciarMusicaFondo", 15f);
    }

    void IniciarMusicaFondo()
    {
        // Asegúrate de que la música de fondo no esté ya reproduciéndose
        if (!musicaFondo.isPlaying)
        {
            // Inicia la reproducción de la música de fondo
            musicaFondo.Play();
        }
    }
}
