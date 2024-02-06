using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider; // Referencia al Slider que representa la vida del jugador
    public float damageThreshold = -25f; // Posición Z en la que se aplica daño al jugador
    public float damageAmount = 10f; // Cantidad de daño que se aplica al jugador

    private float currentHealth; // Vida actual del jugador

    // Diccionario para llevar el control de si cada enemigo ha aplicado daño al jugador
    private Dictionary<GameObject, bool> enemyDamageApplied = new Dictionary<GameObject, bool>();

    void Start()
    {
        // Inicializar la vida del jugador
        currentHealth = healthSlider.maxValue;
        UpdateHealthUI();
    }

    void Update()
    {
        // Comprobar si algún enemigo ha pasado la posición Z deseada
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("SpaceShipEnemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.position.z <= damageThreshold && !enemyDamageApplied.ContainsKey(enemy))
            {
                // Aplicar daño al jugador
                TakeDamage(damageAmount);
                enemyDamageApplied.Add(enemy, true); // Marcar el enemigo como que ya ha aplicado daño
            }
        }
    }

    void TakeDamage(float amount)
    {
        // Restar la cantidad de daño a la vida del jugador
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, healthSlider.maxValue); // Asegurarse de que la vida no sea negativa
        UpdateHealthUI();

        // Comprobar si el jugador ha muerto
        if (currentHealth <= 0f)
        {
            // Aquí puedes hacer algo cuando el jugador muere, como reiniciar el nivel o mostrar un mensaje de game over
            Debug.Log("¡El jugador ha muerto!");
        }
    }

    void UpdateHealthUI()
    {
        // Actualizar el valor del Slider para reflejar la vida actual del jugador
        healthSlider.value = currentHealth;
    }
}



