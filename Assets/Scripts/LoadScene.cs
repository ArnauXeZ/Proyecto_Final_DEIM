using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Nombre de la escena que quieres cargar
    public string Game = "NombreDeTuEscena";
    public string Reiniciar = "NombreDeTuEscena";

    // M�todo que se llama al presionar el bot�n de reproducci�n
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
}
