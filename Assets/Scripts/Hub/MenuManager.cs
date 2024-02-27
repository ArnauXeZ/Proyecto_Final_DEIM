using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject siguienteNivel; // Objeto que se activará cuando se desbloquee el siguiente nivel
    public Button spaceWar;
    public Button overtaking;

    void Start()
    {
        // Verificar si el siguiente nivel está desbloqueado
        if (PlayerPrefs.GetInt("SiguienteNivelDesbloqueado", 0) == 1)
        {
            Navigation nav = spaceWar.navigation;
            nav.mode = Navigation.Mode.Explicit;
            nav.selectOnRight = spaceWar;
            nav.selectOnLeft = overtaking;
            spaceWar.navigation = nav;
            siguienteNivel.SetActive(false);
        }
    }
}

