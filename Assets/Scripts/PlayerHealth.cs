using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider; // Referencia al Slider que representa la vida del jugador
    public float damageThreshold = -25f; // Posici�n Z en la que se aplica da�o al jugador
    public float damageAmount = 10f; // Cantidad de da�o que se aplica al jugador

    private float currentHealth; // Vida actual del jugador

    void Start()
    {
        // Inicializar la vida del jugador
        currentHealth = healthSlider.maxValue;
        UpdateHealthUI();
    }

    void Update()
    {
        // Comprobar si alg�n enemigo ha pasado la posici�n Z deseada
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("SpaceShipEnemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.position.z <= damageThreshold)
            {
                // Aplicar da�o al jugador
                TakeDamage(damageAmount);
                break; // Salir del bucle despu�s de aplicar el da�o una vez
            }
        }
    }

    void TakeDamage(float amount)
    {
        // Restar la cantidad de da�o a la vida del jugador
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, healthSlider.maxValue); // Asegurarse de que la vida no sea negativa
        UpdateHealthUI();

        // Comprobar si el jugador ha muerto
        if (currentHealth <= 0f)
        {
            // Aqu� puedes hacer algo cuando el jugador muere, como reiniciar el nivel o mostrar un mensaje de game over
            Debug.Log("�El jugador ha muerto!");
        }
    }

    void UpdateHealthUI()
    {
        // Actualizar el valor del Slider para reflejar la vida actual del jugador
        healthSlider.value = currentHealth;
    }
}


