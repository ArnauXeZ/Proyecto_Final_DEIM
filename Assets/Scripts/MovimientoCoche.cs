using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCoche : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Ajusta la velocidad seg�n sea necesario

    void Update()
    {
        // Obt�n la entrada de teclado para el movimiento lateral
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Calcula la posici�n actual del coche
        Vector3 posicionActual = transform.position;

        // Calcula la nueva posici�n del coche con el movimiento lateral
        float nuevaPosicionX = posicionActual.x + (movimientoHorizontal * velocidadMovimiento * Time.deltaTime);

        // Limita la posici�n del coche para que no se salga de la carretera
        nuevaPosicionX = Mathf.Clamp(nuevaPosicionX, -7f, 5f); // Ajusta los l�mites seg�n sea necesario

        // Asigna la nueva posici�n al coche
        transform.position = new Vector3(nuevaPosicionX, posicionActual.y, posicionActual.z);
    }
}
