using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public Text waveNumberText;
    public WaveManager waveManager; // Asegúrate de asignar el script WaveManager en el Inspector

    private void Start()
    {
        if (waveNumberText == null)
        {
            Debug.LogError("Asigna un objeto de tipo Text al campo 'waveNumberText' en el Inspector.");
        }

        if (waveManager == null)
        {
            Debug.LogError("Asigna el script WaveManager al campo 'waveManager' en el Inspector.");
        }
    }

    private void Update()
    {
        // Actualiza el texto con el número de la oleada actual
        if (waveNumberText != null && waveManager != null)
        {
            waveNumberText.text = "Wave " + waveManager.GetCurrentWaveNumber();
        }
    }
}

