using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Nombre de la escena que quieres cargar
    public string Game = "NombreDeTuEscena";
    public string Reiniciar = "NombreDeTuEscena";
    public string Options = "NombreDeTuEscena";
    public string Menu = "NombreDeTuEscena";


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
}
