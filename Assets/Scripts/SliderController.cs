using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider tiempoSlider;
    public float tiempoTotal = 60f; // Tiempo total en segundos
    private float tiempoRestante;

    void Start()
    {
        tiempoRestante = tiempoTotal;
        tiempoSlider.maxValue = tiempoTotal;
        tiempoSlider.value = tiempoTotal;
    }

    void Update()
    {
        // Disminuye el tiempo restante
        tiempoRestante -= Time.deltaTime;

        // Actualiza el valor del slider
        tiempoSlider.value = tiempoRestante;

        // Comprueba si el tiempo ha llegado a cero
        if (tiempoRestante <= 0f)
        {
            // Detén el tiempo del juego
            Time.timeScale = 0f;
            // Puedes agregar aquí cualquier acción adicional cuando el tiempo llega a cero
        }
    }
}

