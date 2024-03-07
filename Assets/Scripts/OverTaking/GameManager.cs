using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float tiempoTranscurrido = 0f;
  
    void Update()
    {
        
        // Incrementar el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Guardar el tiempo transcurrido en PlayerPrefs
        PlayerPrefs.SetFloat("TiempoTranscurrido", tiempoTranscurrido);

        // Comprobar si se han superado los 100 segundos
        if (tiempoTranscurrido >= 100f)
        {
            // Marcar el siguiente nivel como desbloqueado
            Debug.Log("SpaceWarDesbloqueado");
            PlayerPrefs.SetInt("SiguienteNivelDesbloqueado", 1);
        }
    }
}



