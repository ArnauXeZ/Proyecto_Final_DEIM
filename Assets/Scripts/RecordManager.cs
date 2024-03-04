using UnityEngine;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour
{
    public Text recordText; // Referencia al objeto Text en la interfaz de usuario

    void Start()
    {
        // Obtener el récord de segundos guardado en PlayerPrefs
        float recordGuardado = PlayerPrefs.GetFloat("Record", 0f);

        // Actualizar el texto para mostrar el récord de segundos
        recordText.text = "Record: " + recordGuardado.ToString("F2") + " segundos";
    }
}

