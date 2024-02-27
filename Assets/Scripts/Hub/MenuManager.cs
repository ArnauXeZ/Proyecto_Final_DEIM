using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject siguienteNivel; // Objeto que se activar� cuando se desbloquee el siguiente nivel

    void Start()
    {
        // Verificar si el siguiente nivel est� desbloqueado
        if (PlayerPrefs.GetInt("SiguienteNivelDesbloqueado", 0) == 1)
        {
            // Activar el objeto del siguiente nivel
            siguienteNivel.SetActive(false);
        }
    }
}

