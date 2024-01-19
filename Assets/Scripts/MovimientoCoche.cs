using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCoche : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Ajusta la velocidad según sea necesario

    void Update()
    {
        // Obtén la entrada de teclado para el movimiento lateral
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Calcula la posición actual del coche
        Vector3 posicionActual = transform.position;

        // Calcula la nueva posición del coche con el movimiento lateral
        float nuevaPosicionX = posicionActual.x + (movimientoHorizontal * velocidadMovimiento * Time.deltaTime);

        // Limita la posición del coche para que no se salga de la carretera
        nuevaPosicionX = Mathf.Clamp(nuevaPosicionX, -7f, 5f); // Ajusta los límites según sea necesario

        // Asigna la nueva posición al coche
        transform.position = new Vector3(nuevaPosicionX, posicionActual.y, posicionActual.z);
    }
}
