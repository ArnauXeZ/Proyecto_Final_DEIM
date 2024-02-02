using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovment : MonoBehaviour
{
    public float aceleracion = 20f;
    public float frenado = 10f;
    public float velocidadMaxima = 10f;
    public float inclinacionMaxima = 30f;
    public float friccion = 5f;
    private float velocidad;
    public GameObject m_shotPrefab;
    public Transform m_muzzle;
    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Aceleración y movimiento lateral
        velocidad += movimientoHorizontal * aceleracion * Time.deltaTime;
        velocidad = Mathf.Clamp(velocidad, -velocidadMaxima, velocidadMaxima);
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);

        // Restringe la posición lateral del coche para evitar salir del mapa
        float nuevaPosicionX = Mathf.Clamp(transform.position.x, -45f, 45f);
        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);

        transform.Translate(Vector3.right * velocidad * Time.deltaTime);

        // Frenado suave
        if (movimientoHorizontal == 0)
        {
            float frenadoSuave = Mathf.Sign(velocidad) * frenado * Time.deltaTime;
            velocidad -= frenadoSuave;
        }

        // Rotación del coche
        float inclinacion = -movimientoHorizontal * inclinacionMaxima;
        transform.rotation = Quaternion.Euler(0, 0, inclinacion);

        // Simulación de fricción
        velocidad *= Mathf.Pow(1 - friccion * Time.deltaTime, 2);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject;
            GameObject.Destroy(go, 3f);
        }
    }
}
