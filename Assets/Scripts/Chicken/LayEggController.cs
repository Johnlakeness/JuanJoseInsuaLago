using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayEggController : MonoBehaviour
{
    // Zona de variables globales

    [SerializeField]
    // Huevo a instanciar
    private GameObject eggObject;

    [SerializeField]
    // Origen del huevo
    private Transform eggOrigin;

    [SerializeField]
    // Fisicas del huevo
    private float _eggSpeed = 5.0f,
                  _eggForce;

    [SerializeField]
    // Temporizador "Destroy"
    private float _eggTimer = 10.0f;

    // Update is called once per frame
    void Update()
    {

        LayEgg();

    }

    private void LayEgg()
    {
        
        if (Input.GetMouseButtonDown(0))
        {

            // Ubicación y rotación del "spawn" del huevo
            Vector3 eggPosition = eggOrigin.position;
            Quaternion eggRotation = eggOrigin.rotation;

            // Instancia del huevo
            GameObject eggClone = Instantiate(eggObject, eggPosition, eggRotation);

            // Llamada al componente "rigidbody" de la instancia
            Rigidbody eggRigidBody;
            eggRigidBody = eggClone.GetComponent<Rigidbody>();

            // Añadir valor a las físicas de la instancia
            eggRigidBody.AddForce(-transform.forward * _eggSpeed);
            eggRigidBody.AddForce(transform.up * _eggForce);

            // Destruir instancia
            Destroy(eggClone, _eggTimer);

        }
    }
}
