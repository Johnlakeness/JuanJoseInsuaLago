using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Zona de Variables Globales

    [SerializeField]
    // Velocidad de movimiento y rotación
    private float _movementSpeed = 1.2f,
                  _turnSpeed = 90.0f;

    // Variables vinculadas al valor "Input.GetAxis"
    private float _horizontal;
    private float _vertical;

    // Llamada a "Animator"
    private Animator _anim;

    // Start "Awake"
    private void Awake()
    {

        _anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Input();
        Move();
        Rotate();
        Animating();
    }

    private void Input()
    {

        // Valor Teclas Movimiento
        _horizontal = UnityEngine.Input.GetAxis("Horizontal");
        _vertical = UnityEngine.Input.GetAxis("Vertical");

    }

    // Método movimiento (W/S)
    private void Move()
    {

        transform.Translate(Vector3.forward * _movementSpeed * _vertical * Time.deltaTime); 

    }

    // Método rotación (A/S)
    private void Rotate()
    {

        transform.Rotate(Vector3.up * _turnSpeed * _horizontal * Time.deltaTime);

    }

    // Método animación de la gallina
    private void Animating()
    {

        if(_vertical != 0)
        {
            _anim.SetBool("IsMoving", true);
        }

        else
        {
            _anim.SetBool("IsMoving", false);
        }

    }
}
