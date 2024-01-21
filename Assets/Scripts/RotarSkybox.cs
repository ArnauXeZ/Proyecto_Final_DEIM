using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarSkybox : MonoBehaviour
{
    public float velocidadRotacion = 1f; // Ajusta la velocidad de rotación según tus preferencias

    void Update()
    {
        // Obtén el material del skybox
        Material skyboxMaterial = RenderSettings.skybox;

        // Calcula la nueva rotación del skybox
        float nuevaRotacion = skyboxMaterial.GetFloat("_Rotation") + velocidadRotacion * Time.deltaTime;

        // Aplica la nueva rotación al material del skybox
        skyboxMaterial.SetFloat("_Rotation", nuevaRotacion);
    }
}
