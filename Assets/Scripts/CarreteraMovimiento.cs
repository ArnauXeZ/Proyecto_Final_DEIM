using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarreteraMovimiento : MonoBehaviour
{
    public float velocidad = 5f; // Ajusta la velocidad seg�n sea necesario

    void Update()
    {
        // Mueve la carretera hacia atr�s
        transform.Translate(Vector3.back * velocidad * Time.deltaTime);

        // Si la carretera ha pasado cierta posici�n, reposici�nala para crear el bucle
        if (transform.position.z < -80f)
        {
            RepositionarCarretera();
        }
    }

    void RepositionarCarretera()
    {
        // Calcula la nueva posici�n de la carretera para reposicionarla
        float longitudCarretera = 80f; // Ajusta seg�n la longitud de tu carretera
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + longitudCarretera);
    }
}
