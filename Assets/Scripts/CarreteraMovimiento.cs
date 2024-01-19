using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarreteraMovimiento : MonoBehaviour
{
    public float velocidadBase = 5f;
    public GameObject cochePrefab;
    private float temporizador = 0f;

    void Update()
    {
        // Mueve la carretera hacia atr�s
        transform.Translate(Vector3.back * ObtenerVelocidadCarretera() * Time.deltaTime);

        // Incrementa el temporizador
        temporizador += Time.deltaTime;

        // Si la carretera ha pasado cierta posici�n, reposici�nala para crear el bucle
        if (transform.position.z < -80f)
        {
            RepositionarCarretera();
            GenerarCocheContrario();
        }
    }

    void RepositionarCarretera()
    {
        // Calcula la nueva posici�n de la carretera para reposicionarla
        float longitudCarretera = 80f; // Ajusta seg�n la longitud de tu carretera
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + longitudCarretera);
    }

    void GenerarCocheContrario()
    {
        // Genera un coche en sentido contrario en una posici�n aleatoria
        Vector3 posicionCoche = new Vector3(Random.Range(-5f, 5f), 1f, transform.position.z + 80f);
        GameObject cocheContrario = Instantiate(cochePrefab, posicionCoche, Quaternion.identity);
        cocheContrario.GetComponent<MovimientoCocheContrario>().ConfigurarVelocidad(ObtenerVelocidadCarretera());
    }

    public float ObtenerVelocidadCarretera()
    {
        // Incrementa la velocidad base en funci�n del tiempo
        return velocidadBase + temporizador * 2.5f;
    }
}
