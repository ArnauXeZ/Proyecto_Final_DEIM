using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarSkybox : MonoBehaviour
{
    public float rotationSpeed = 1f; // Ajusta la velocidad de rotaci�n seg�n tus preferencias

    void Update()
    {
        // Obtenemos la rotaci�n actual del skybox
        float rotation = RenderSettings.skybox.GetFloat("_Rotation");

        // Calculamos la nueva rotaci�n en el eje horizontal
        rotation += Time.deltaTime * rotationSpeed;
        rotation %= 360.0f; // Aseguramos que la rotaci�n est� en el rango de 0 a 360 grados

        // Establecemos la nueva rotaci�n del skybox
        RenderSettings.skybox.SetFloat("_Rotation", rotation);
    }
}
