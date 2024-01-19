using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarreteraMovimiento : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        // Mueve la carretera hacia atrás
        transform.Translate(Vector3.back * velocidad * Time.deltaTime);

        // Si la carretera ha pasado cierta posición, reposiciónala para crear el bucle
        if (transform.position.z < -80f)
        {
            RepositionarCarretera();
        }
    }

    void RepositionarCarretera()
    {
        // Calcula la nueva posición de la carretera para reposicionarla
        float longitudCarretera = 80f; // Ajusta según la longitud de tu carretera
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + longitudCarretera);
    }

    // Nuevo método para obtener la velocidad de la carretera
    public float ObtenerVelocidadCarretera()
    {
        return velocidad;
    }
}
