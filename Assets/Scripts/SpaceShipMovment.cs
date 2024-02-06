using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovment : MonoBehaviour
{
    public float aceleracion = 20f;
    public float frenado = 10f;
    public float velocidadMaxima = 10f;
    public float inclinacionMaxima = 30f;
    public float friccion = 5f;
    private float velocidad;
    public GameObject m_shotPrefab;
    public Transform m_muzzle;
    public Transform m_muzzle2;
    [SerializeField] private AudioClip blast;

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Aceleraci�n y movimiento lateral
        velocidad += movimientoHorizontal * aceleracion * Time.deltaTime;
        velocidad = Mathf.Clamp(velocidad, -velocidadMaxima, velocidadMaxima);
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);

        // Restringe la posici�n lateral de la nave para evitar salir del mapa
        float nuevaPosicionX = Mathf.Clamp(transform.position.x, -45f, 45f);
        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);

        transform.Translate(Vector3.right * velocidad * Time.deltaTime);

        // Frenado suave
        if (movimientoHorizontal == 0)
        {
            float frenadoSuave = Mathf.Sign(velocidad) * frenado * Time.deltaTime;
            velocidad -= frenadoSuave;
        }

        // Rotaci�n de la navee
        float inclinacion = -movimientoHorizontal * inclinacionMaxima;
        transform.rotation = Quaternion.Euler(0, 0, inclinacion);

        // Simulaci�n de fricci�n
        velocidad *= Mathf.Pow(1 - friccion * Time.deltaTime, 2);

        //Disparar
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Disparo"))
        {
            ControladorSonido.Instance.EjecutarSonido(blast);
            GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject;
            GameObject.Destroy(go, 3f);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Disparo"))
        {
            GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle2.position, m_muzzle.rotation) as GameObject;
            GameObject.Destroy(go, 3f);
        }
    }
}
