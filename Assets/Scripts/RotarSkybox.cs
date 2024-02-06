using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarSkybox : MonoBehaviour
{
    public float rotationSpeed = 1f; // Ajusta la velocidad de rotación según tus preferencias

    void Update()
    {
        // Obtenemos la rotación actual del skybox
        float rotation = RenderSettings.skybox.GetFloat("_Rotation");

        // Calculamos la nueva rotación en el eje horizontal
        rotation += Time.deltaTime * rotationSpeed;
        rotation %= 360.0f; // Aseguramos que la rotación esté en el rango de 0 a 360 grados

        // Establecemos la nueva rotación del skybox
        RenderSettings.skybox.SetFloat("_Rotation", rotation);
    }
}
