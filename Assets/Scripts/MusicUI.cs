using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicUI : MonoBehaviour
{
    public Text textoNombreCancion;
    public CambioMusica cambioMusica; // Asegúrate de asignar el script CambioMusica en el Inspector

    void Start()
    {
        if (textoNombreCancion == null)
        {
            Debug.LogError("Asigna un objeto de tipo Text al campo 'textoNombreCancion' en el Inspector.");
        }

        if (cambioMusica == null)
        {
            Debug.LogError("Asigna el script CambioMusica al campo 'cambioMusica' en el Inspector.");
        }
    }

    void Update()
    {
        // Actualiza el texto con el nombre de la canción actual
        if (textoNombreCancion != null && cambioMusica != null)
        {
            textoNombreCancion.text = "Listening " + cambioMusica.ObtenerNombreCancionActual();
        }
    }
}
