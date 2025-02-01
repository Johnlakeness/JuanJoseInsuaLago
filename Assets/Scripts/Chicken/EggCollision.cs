using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCollision : MonoBehaviour
{

    // Zona de variables globales
    
    [SerializeField]
    // F�sicas del huevo
    private float _eggCollisionSpeed = 50.0f,
                  _eggCollisionForce = 50.0f;

    [SerializeField]
    // Temporizador
    private float _eggTimer = 1.0f;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Chicken"))
        {

            Rigidbody eggRigidBody = GetComponent<Rigidbody>();

            // A�adir valor a las f�sicas
            eggRigidBody.AddForce(-transform.forward * _eggCollisionSpeed);
            eggRigidBody.AddForce(transform.up * _eggCollisionForce);

            // Destruir huevo
            Destroy(gameObject, _eggTimer);

        }
    }
}
