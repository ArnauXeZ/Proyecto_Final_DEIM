using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarreteraMovimiento : MonoBehaviour
{
    public float velocidadBase = 5f;
    public GameObject cochePrefab;
    public GameObject ambulanciaPrefab;
    private float temporizador = 0f;
    public Slider barraSlider;

    void Update()
    {
        //Debug.Log("Update de CarreteraMovimiento");

        // Mueve la carretera hacia atrás
        transform.Translate(Vector3.back * ObtenerVelocidadCarretera() * Time.deltaTime);

        // Incrementa el temporizador
        temporizador += Time.deltaTime;

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

        // Genera una ambulancia cada vez que la carretera se reposiciona
        GenerarAmbulanciaContraria();
    }

    void GenerarCocheContrario()
    {
        // Genera un coche en sentido contrario en una posición aleatoria
        Vector3 posicionCoche = new Vector3(Random.Range(-5f, 5f), 1f, transform.position.z + 80f);
        GameObject cocheContrario = Instantiate(cochePrefab, posicionCoche, Quaternion.identity);

        // Configura la referencia al slider en el script MovimientoCoche
        cocheContrario.GetComponent<MovimientoCocheContrario>().ConfigurarVelocidad(ObtenerVelocidadCarretera());

        // Guarda una referencia al script MovimientoCoche
        MovimientoCoche movimientoCoche = cocheContrario.GetComponent<MovimientoCoche>();

        /* Asegúrate de que el cocheContrario tenga el componente MovimientoCoche
        if (movimientoCoche != null)
        {
            // Configura la referencia al slider en el script MovimientoCoche
            movimientoCoche.ConfigurarSlider(barraSlider);
        }
        else
        {
            Debug.LogError("El objeto cocheContrario no tiene el componente MovimientoCoche.");
        }*/

    }

    void GenerarAmbulanciaContraria()
    {
        // Genera una ambulancia en sentido contrario en una posición aleatoria
        Debug.Log("Generando ambulancia...");
        Vector3 posicionAmbulancia = new Vector3(Random.Range(-5f, 5f), 1f, transform.position.z + 70f);
        GameObject ambulanciaContraria = Instantiate(ambulanciaPrefab, posicionAmbulancia, Quaternion.identity);

        // Obtén la referencia al script MovimientoAmbulanciaContraria
        MovimientoAmbulanciaContraria movimientoAmbulancia = ambulanciaContraria.GetComponent<MovimientoAmbulanciaContraria>();

        // Configura la velocidad y pasa la referencia del slider al script MovimientoAmbulanciaContraria
        movimientoAmbulancia.ConfigurarVelocidad(ObtenerVelocidadCarretera());
        movimientoAmbulancia.ConfigurarSlider(barraSlider);
    }


    public float ObtenerVelocidadCarretera()
    {
        // Incrementa la velocidad base en función del tiempo
        return velocidadBase + temporizador * 1f;
    }

    /* void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ambulancia"))
        {
            // No detenemos el tiempo aquí, sino que simplemente incrementamos la barra del slider
            barraSlider.value += 10;
        }
    }*/
}
