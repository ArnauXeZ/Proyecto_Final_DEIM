using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Comenzar la reproducci�n de la m�sica de fondo
        audioSource.Play();
    }

    // Funci�n para pausar la reproducci�n de la m�sica
    public void PausarMusica()
    {
        audioSource.Pause();
    }

    // Funci�n para reanudar la reproducci�n de la m�sica
    public void ReanudarMusica()
    {
        audioSource.UnPause();
    }
}
