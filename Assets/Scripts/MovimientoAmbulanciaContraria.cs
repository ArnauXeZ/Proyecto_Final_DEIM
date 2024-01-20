using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAmbulanciaContraria : MonoBehaviour
{
    private float velocidad;

    void Update()
    {
        // Mueve la ambulancia hacia atr�s
        transform.Translate(Vector3.back * velocidad * Time.deltaTime);

        // Si el coche est� fuera de la pantalla, destr�yelo
        if (transform.position.z < -80f)
        {
            Destroy(gameObject);
        }
    }

    // Configura la velocidad de la ambulancia
    public void ConfigurarVelocidad(float velocidadCarretera)
    {
        velocidad = velocidadCarretera * 1.5f; // Ajusta el factor de velocidad seg�n tus necesidades
    }
}
