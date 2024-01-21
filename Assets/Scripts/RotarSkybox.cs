using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarSkybox : MonoBehaviour
{
    public float velocidadRotacion = 1f; // Ajusta la velocidad de rotaci�n seg�n tus preferencias

    void Update()
    {
        // Obt�n el material del skybox
        Material skyboxMaterial = RenderSettings.skybox;

        // Calcula la nueva rotaci�n del skybox
        float nuevaRotacion = skyboxMaterial.GetFloat("_Rotation") + velocidadRotacion * Time.deltaTime;

        // Aplica la nueva rotaci�n al material del skybox
        skyboxMaterial.SetFloat("_Rotation", nuevaRotacion);
    }
}
