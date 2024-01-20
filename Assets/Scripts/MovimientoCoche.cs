using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCoche : MonoBehaviour
{
    public float aceleracion = 20f;
    public float frenado = 10f;
    public float velocidadMaxima = 10f;
    public float inclinacionMaxima = 30f;
    public float friccion = 5f;
    public Transform ruedaDelanteraIzquierda;
    public Transform ruedaDelanteraDerecha;
    public Transform ruedaTraseraIzquierda;
    public Transform ruedaTraseraDerecha;
    public GameObject carretera; // Arrastra el objeto de la carretera aquí

    private float velocidad;

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Aceleración y movimiento lateral
        velocidad += movimientoHorizontal * aceleracion * Time.deltaTime;
        velocidad = Mathf.Clamp(velocidad, -velocidadMaxima, velocidadMaxima);
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);

        // Restringe la posición lateral del coche para evitar salir del mapa
        float nuevaPosicionX = Mathf.Clamp(transform.position.x, -7f, 5f);
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

        // Rotación de las ruedas basada en la velocidad de la carretera
        RotarRuedas();
    }

    void RotarRuedas()
    {
        float rotacionRuedas = carretera.GetComponent<CarreteraMovimiento>().ObtenerVelocidadCarretera() * 20f;

        // Rotar las ruedas delanteras
        ruedaDelanteraIzquierda.Rotate(Vector3.right, rotacionRuedas * Time.deltaTime);
        ruedaDelanteraDerecha.Rotate(Vector3.right, rotacionRuedas * Time.deltaTime);

        // Rotar las ruedas traseras
        ruedaTraseraIzquierda.Rotate(Vector3.right, rotacionRuedas * Time.deltaTime);
        ruedaTraseraDerecha.Rotate(Vector3.right, rotacionRuedas * Time.deltaTime);
    }

    // Maneja las colisiones con los coches en sentido contrario
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CocheContrario")
        {
            // Detener el tiempo al colisionar con un coche en sentido contrario
            Time.timeScale = 0f;
        }
    }

}
