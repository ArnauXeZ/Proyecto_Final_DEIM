using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float tiempoTranscurrido = 0f;

    void Update()
    {
        // Incrementar el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Guardar el tiempo transcurrido en PlayerPrefs
        PlayerPrefs.SetFloat("TiempoTranscurrido", tiempoTranscurrido);

        // Comprobar si el tiempo supera los 100 segundos
        if (tiempoTranscurrido >= 100f)
        {
            // Cargar la escena aditivamente si aún no está cargada
            if (!SceneManager.GetSceneByName("ArcadeHUB").isLoaded)
            {

                SceneManager.LoadScene("ArcadeHUB", LoadSceneMode.Additive);
            }

            // Acceder al objeto y activarlo
            GameObject objetoVisible = GameObject.FindWithTag("LockSpaceWar");
            if (objetoVisible != null)
            {
                Debug.Log("SpaceWarDesbloqueado");
                objetoVisible.SetActive(false);
            }
        }
    }
}


