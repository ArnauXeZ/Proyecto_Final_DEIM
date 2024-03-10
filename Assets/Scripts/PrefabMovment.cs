using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMovement : MonoBehaviour
{
    public float velocidad;

    void Update()
    {
        transform.Translate(Vector3.back * velocidad * Time.deltaTime);

        if (transform.position.z < -25f)
        {
            Destroy(gameObject);
        }
    }
}

