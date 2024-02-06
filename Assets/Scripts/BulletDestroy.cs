using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("SpaceShipEnemy"))
        {
            Destroy(gameObject);
        }
    }
}
