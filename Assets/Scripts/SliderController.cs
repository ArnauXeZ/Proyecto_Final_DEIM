using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("GameOver 1");
            Time.timeScale = 0f;
            // Puedes agregar aquí cualquier acción adicional cuando el tiempo llega a cero
        }
    }
    
    // Método para aumentar el tiempo restante
    public void AumentarTiempo(float cantidad)
    {
        tiempoRestante += cantidad;
        tiempoRestante = Mathf.Clamp(tiempoRestante, 0f, tiempoTotal); // Asegura que no exceda el tiempo total
        tiempoSlider.value = tiempoRestante;
    }
}

