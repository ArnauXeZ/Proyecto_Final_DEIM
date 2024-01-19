using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarreteraMovimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public GameObject cochePrefab; // Arrastra el prefab del coche en sentido contrario aquí

    void Update()
    {
        // Mueve la carretera hacia atrás
        transform.Translate(Vector3.back * velocidad * Time.deltaTime);

        // Si la carretera ha pasado cierta posición, reposiciónala para crear el bucle
        if (transform.position.z < -80f)
        {
            RepositionarCarretera();
            GenerarCocheContrario();
        }
    }

    void RepositionarCarretera()
    {
        // Calcula la nueva posición de la carretera para reposicionarla
        float longitudCarretera = 80f; // Ajusta según la longitud de tu carretera
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + longitudCarretera);
    }

    void GenerarCocheContrario()
    {
        // Genera un coche en sentido contrario en una posición aleatoria
        Vector3 posicionCoche = new Vector3(Random.Range(-5f, 5f), 1f, transform.position.z + 80f);
        Instantiate(cochePrefab, posicionCoche, Quaternion.identity);
    }

    // Asegúrate de tener este método en tu script CarreteraMovimiento
    public float ObtenerVelocidadCarretera()
    {
        return velocidad;
    }
}
