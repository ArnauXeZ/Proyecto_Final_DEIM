using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioMusica : MonoBehaviour
{
    public List<AudioClip> pistasDeFondo;
    private AudioSource audioSource;
    private int indiceActual = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Asegúrate de tener al menos una pista de fondo en la lista
        if (pistasDeFondo.Count > 0)
        {
            // Inicia reproduciendo la primera pista
            ReproducirPista(0);
        }
        else
        {
            Debug.LogError("Añade al menos una pista de fondo a la lista.");
        }
    }

    void Update()
    {
        // Detecta si se presiona el botón cuadrado en el controlador de PS4
        if (Input.GetButtonDown("Cuadrado"))
        {
            // Cambia a la siguiente pista
            CambiarPistaSiguiente();
        }
    }

    public string ObtenerNombreCancionActual()
    {
        if (indiceActual >= 0 && indiceActual < pistasDeFondo.Count)
        {
            return pistasDeFondo[indiceActual].name;
        }

        return "Nombre de Canción No Disponible";
    }

    void CambiarPistaSiguiente()
    {
        // Aumenta el índice y vuelve al principio si llega al final de la lista
        indiceActual = (indiceActual + 1) % pistasDeFondo.Count;

        // Reproduce la nueva pista
        ReproducirPista(indiceActual);
    }

    void ReproducirPista(int indice)
    {
        // Detiene la reproducción actual (si hay alguna)
        audioSource.Stop();

        // Establece la nueva pista
        audioSource.clip = pistasDeFondo[indice];

        // Inicia la reproducción
        audioSource.Play();
    }
}
