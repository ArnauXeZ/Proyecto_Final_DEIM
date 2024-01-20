using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoAmbulanciaContraria : MonoBehaviour
{
    private float velocidad;
    private Slider barraSlider;

    void Update()
    {
        // Mueve la ambulancia hacia atrás
        transform.Translate(Vector3.back * velocidad * Time.deltaTime);

        // Si la ambulancia está fuera de la pantalla, destrúyela
        if (transform.position.z < -80f)
        {
            Destroy(gameObject);
        }
    }

    // Configura la velocidad de la ambulancia
    public void ConfigurarVelocidad(float velocidadCarretera)
    {
        velocidad = velocidadCarretera * 1f; // Ajusta el factor de velocidad según tus necesidades
    }

    // Configura el slider en la ambulancia
    public void ConfigurarSlider(Slider slider)
    {
        barraSlider = slider;
    }

    // Maneja las colisiones con las ambulancias
    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CocheJugador"))
        {
            // Incrementa la barra del slider en 10 puntos cuando colisiona con el coche del jugador
            barraSlider.value += 10;
            Destroy(gameObject); // Destruye la ambulancia al colisionar con el coche del jugador
        }
    }*/
}


