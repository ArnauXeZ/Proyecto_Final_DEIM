using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    // Nombre de la escena que quieres cargar
    public string Game = "NombreDeTuEscena";
    public string Reiniciar = "NombreDeTuEscena";
    public string Options = "NombreDeTuEscena";
    public string Menu = "NombreDeTuEscena";
    public string Hub = "NombreDeTuEscena";
    public string VideoIntro = "NombreDeTuEscena";
    

    // Método que se llama al presionar el botón de reproducción
    public void CargarEscena()
    {
        // Cargar la escena por su nombre
        SceneManager.LoadScene(Game);
    }

    public void ReiniciarEscena()
    {
        // Cargar la escena por su nombre
        SceneManager.LoadScene(Reiniciar);
    }

    public void CargarOptions()
    {
        SceneManager.LoadScene(Options);
    }
    public void CargarMenu()
    {
        SceneManager.LoadScene(Menu);
    }
    public void CargarHub()
    {
        SceneManager.LoadScene(Hub);
    }
    
    public void CargarVideoIntro()
    {
        SceneManager.LoadScene(VideoIntro);
    }

    public void ResetPref()
    {
        PlayerPrefs.DeleteAll();
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Cierra la aplicación
    }
}
