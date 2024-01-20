using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCocheContrario : MonoBehaviour
{
    private float velocidad;

    void Update()
    {
        // Mueve el coche en sentido contrario hacia abajo
        transform.Translate(Vector3.back * velocidad * Time.deltaTime);

        // Si el coche está fuera de la pantalla, destrúyelo
        if (transform.position.z < -80f)
        {
            Destroy(gameObject);
        }
    }

    // Configura la velocidad del coche contrario
    public void ConfigurarVelocidad(float velocidadCarretera)
    {
        velocidad = velocidadCarretera * 1f; // Ajusta el multiplicador según sea necesario
    }
}
