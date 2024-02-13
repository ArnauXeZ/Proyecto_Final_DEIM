using UnityEngine;


public class PowerUP : MonoBehaviour
{
    public GameObject particlesPrefab; // Prefab del efecto de partículas
    private WaveManager waveManager;
    [SerializeField] private AudioClip explosion;




    public void SetWaveManager(WaveManager manager)
    {
        waveManager = manager;
    }

    private void OnDestroy()
    {

        ControladorSonido.Instance.EjecutarSonido(explosion);
        // Instanciar el efecto de partículas en la posición del enemigo
        Instantiate(particlesPrefab, transform.position, Quaternion.identity);

        if (waveManager != null)
        {
            waveManager.PowerUpCollected();
        }

        // Llamar al script de control de vibración
        FindObjectOfType<PruebaMando>().StartCoroutine("Vibracion");
    }

}
