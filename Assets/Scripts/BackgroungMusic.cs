using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Comenzar la reproducción de la música de fondo
        audioSource.Play();
    }

    // Función para pausar la reproducción de la música
    public void PausarMusica()
    {
        audioSource.Pause();
    }

    // Función para reanudar la reproducción de la música
    public void ReanudarMusica()
    {
        audioSource.UnPause();
    }
}
