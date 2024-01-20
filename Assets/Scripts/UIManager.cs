using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text contadorTiempoText;

    private float tiempoTranscurrido = 0f;
    private bool juegoDetenido = false;

    void Update()
    {
        if (juegoDetenido)
        {
            // El juego est� detenido, no procesar la l�gica del juego.
            return;
        }

        // Resto del c�digo...

        // Incrementa el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Actualiza el contador de tiempo en la interfaz de usuario
        ActualizarContadorTiempo();

        // Resto del c�digo...
    }

    // Resto del c�digo...

    // Maneja las colisiones con los coches en sentido contrario
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CocheContrario")
        {
            // Detener el tiempo al colisionar con un coche en sentido contrario
            Time.timeScale = 0f;
            juegoDetenido = true;
        }
    }

    // Actualiza el contador de tiempo en la interfaz de usuario
    void ActualizarContadorTiempo()
    {
        contadorTiempoText.text = "Tiempo: " + Mathf.Floor(tiempoTranscurrido).ToString();
    }
}
