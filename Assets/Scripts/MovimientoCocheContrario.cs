using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCocheContrario : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        // Mueve el coche en sentido contrario hacia abajo
        transform.Translate(Vector3.back * velocidad * Time.deltaTime);

        // Si el coche est� fuera de la pantalla, destr�yelo
        if (transform.position.z < -80f)
        {
            Destroy(gameObject);
        }
    }
}
