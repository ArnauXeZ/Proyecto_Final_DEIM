using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public ParticleSystem efectoColisionEnemigo;
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log($"{collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("holaaa");
            if (efectoColisionEnemigo != null)
            {
                efectoColisionEnemigo.Play();
            }

            Destroy(gameObject);
        }
    }  
    
}
