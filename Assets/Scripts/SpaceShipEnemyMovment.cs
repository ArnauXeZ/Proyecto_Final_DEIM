using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipEnemyMovment : MonoBehaviour
{
    public float velocidad;

    void Update()
    {
        // Mueve el coche en sentido contrario hacia abajo
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        // Si el coche está fuera de la pantalla, destrúyelo
        if (transform.position.z < -25f)
        {
            Destroy(gameObject);
        }
    }
}
