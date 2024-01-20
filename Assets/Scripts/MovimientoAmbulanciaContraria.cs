using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAmbulanciaContraria : MonoBehaviour
{
    private float velocidad;

    void Update()
    {
        // Mueve la ambulancia hacia atrás
        transform.Translate(Vector3.back * velocidad * Time.deltaTime);

        // Si el coche está fuera de la pantalla, destrúyelo
        if (transform.position.z < -80f)
        {
            Destroy(gameObject);
        }
    }

    // Configura la velocidad de la ambulancia
    public void ConfigurarVelocidad(float velocidadCarretera)
    {
        velocidad = velocidadCarretera * 1.5f; // Ajusta el factor de velocidad según tus necesidades
    }
}
