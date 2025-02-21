using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurretMovement : MonoBehaviour
{

    // Zona de variables gloabales
    [SerializeField]
    private float _turnSpeed;
    private float _turnValue;

    // Update is called once per frame
    void Update()
    {

        InputsTurret();
        Turn();

    }

    private void InputsTurret()
    {

        // Asignación de valor a tecla "E"
        if (Input.GetKey(KeyCode.E))
        {

            _turnValue = 1.0f;

        }

        // Asignación de valor a tecla "Q"
        else if (Input.GetKey(KeyCode.Q))
        {

            _turnValue = -1.0f;

        }

        // Asignación de valor si no se presiona "E" o "Q"
        else
        {

            _turnValue = 0.0f;

        }

    }

    private void Turn()
    {

        // Rotación de la torreta
        transform.Rotate(Vector3.up * _turnSpeed * _turnValue * Time.deltaTime);

    }

}
