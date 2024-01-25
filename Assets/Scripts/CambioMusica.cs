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

        // Aseg�rate de tener al menos una pista de fondo en la lista
        if (pistasDeFondo.Count > 0)
        {
            // Inicia reproduciendo la primera pista
            ReproducirPista(0);
        }
        else
        {
            Debug.LogError("A�ade al menos una pista de fondo a la lista.");
        }
    }

    void Update()
    {
        // Detecta si se presiona el bot�n cuadrado en el controlador de PS4
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

        return "Nombre de Canci�n No Disponible";
    }

    void CambiarPistaSiguiente()
    {
        // Aumenta el �ndice y vuelve al principio si llega al final de la lista
        indiceActual = (indiceActual + 1) % pistasDeFondo.Count;

        // Reproduce la nueva pista
        ReproducirPista(indiceActual);
    }

    void ReproducirPista(int indice)
    {
        // Detiene la reproducci�n actual (si hay alguna)
        audioSource.Stop();

        // Establece la nueva pista
        audioSource.clip = pistasDeFondo[indice];

        // Inicia la reproducci�n
        audioSource.Play();
    }
}
