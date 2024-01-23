using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarreteraMovimiento : MonoBehaviour
{
    public float velocidadBase = 5f;
    public GameObject cochePrefab;
    public GameObject ambulanciaPrefab;
    public GameObject autobusPrefab;
    private float temporizador = 0f;
    public Slider barraSlider;

    void Update()
    {

        // Mueve la carretera hacia atrás
        transform.Translate(Vector3.back * ObtenerVelocidadCarretera() * Time.deltaTime);

        // Incrementa el temporizador
        temporizador += Time.deltaTime;

        // Si la carretera ha pasado cierta posición, reposiciónala para crear el bucle
        if (transform.position.z < -80f)
        {
            RepositionarCarretera();
            GenerarCocheContrario();
            GenerarAmbulanciaContraria();
            GenerarAutobusContrario();
        }

    }

    void RepositionarCarretera()
    {
        // Calcula la nueva posición de la carretera para reposicionarla
        float longitudCarretera = 80f; // Ajusta según la longitud de tu carretera
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + longitudCarretera);

        // Genera una ambulancia cada vez que la carretera se reposiciona
    }

    void GenerarAutobusContrario()
    {
        // Genera un autobús en sentido contrario en una posición aleatoria
        Vector3 posicionAutobus = new Vector3(Random.Range(-5f, 5f), 1f, transform.position.z + 150f);
        GameObject autobusContrario = Instantiate(autobusPrefab, posicionAutobus, Quaternion.identity);
        autobusContrario.GetComponent<MovimientoAutobusContrario>().ConfigurarVelocidad(ObtenerVelocidadCarretera());
    }

    void GenerarCocheContrario()
    {
        // Genera un coche en sentido contrario en una posición aleatoria
        Vector3 posicionCoche = new Vector3(Random.Range(-5f, 5f), 1f, transform.position.z + 100f);
        GameObject cocheContrario = Instantiate(cochePrefab, posicionCoche, Quaternion.identity);

        // Configura la referencia al slider en el script MovimientoCoche
        cocheContrario.GetComponent<MovimientoCocheContrario>().ConfigurarVelocidad(ObtenerVelocidadCarretera());

        // Guarda una referencia al script MovimientoCoche
        MovimientoCoche movimientoCoche = cocheContrario.GetComponent<MovimientoCoche>();


    }

    void GenerarAmbulanciaContraria()
    {
        // Genera una ambulancia en sentido contrario en una posición aleatoria
        Vector3 posicionAmbulancia = new Vector3(Random.Range(-5f, 5f), 0.5f, transform.position.z + 70f);
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
        return velocidadBase + temporizador * 0.3f;
    }

}
