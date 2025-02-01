using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour
{
    // Zona de variables globales

    [SerializeField]
    // Velocidad movimiento y rotaci�n
    private float _speedWalk = 1.0f,
                  _speedRun = 1.8f,
                  _turnSpeed = 90.0f;

    // Variables vinculadas al valor "Input.GetAxis"
    private float _horizontal,
                  _vertical;

    [SerializeField]
    // Variables salto y raycast
    private float _jumpForce = 150.0f,
                  _rayLenght = 0.1f;
    [SerializeField]
    private LayerMask _groundMask;
    private Ray _ray;
    private bool _isGrounded,
                 _canPlayerJump;

    // Rigidbody personaje
    private Rigidbody _rb;

    // Llamada a "Animator"
    private Animator _anim;

    // Preiniciaci�n de componentes
    private void Awake()
    {

        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();

    }


    private void FixedUpdate()
    {

        IsGround();

        if (_canPlayerJump)
        {
            Jump();
            _canPlayerJump = false;

        }
    }

    // Update is called once per frame
    void Update()
    {

        Input();
        Move();
        Rotate();
        CanJump();
        AnimationMovement();
        AnimationJump();

    }

    private void Input()
    {

        // Valor Teclas Movimiento
        _horizontal = UnityEngine.Input.GetAxis("Horizontal");
        _vertical = UnityEngine.Input.GetAxis("Vertical");

    }

    // M�todo movimiento (W/S)
    private void Move()
    {
        // Correr
        if (!UnityEngine.Input.GetKey(KeyCode.LeftShift))
        {

            transform.Translate(Vector3.forward * _vertical * _speedWalk * Time.deltaTime);

        }
        
        // Caminar
        else
        {

            transform.Translate(Vector3.forward * _vertical * _speedRun * Time.deltaTime);

        }
    }

    // M�todo rotaci�n (A/D)
    private void Rotate()
    {

        transform.Rotate(Vector3.up * _horizontal * _turnSpeed  * Time.deltaTime);

    }



    // Raycast desde posici�n de personaje hacia suelo
    private void IsGround()
    {
        // Valor de origen y direcci�n de "_ray"
        _ray.origin = transform.position;
        _ray.direction = -transform.up;

        // Si est� tocando el suelo
        if (Physics.Raycast(_ray.origin, _ray.direction, _rayLenght, _groundMask))
        {

            _isGrounded = true;

        }

        // Si est� en el aire
        else
        {

            _isGrounded = false;

        }

    }

    // Verificaci�n del salto
    private void CanJump()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {

            _canPlayerJump = true;

        }

    }

    // A�adir valor al Rigidbody para saltar
    private void Jump()
    {

        _rb.AddForce(transform.up * _jumpForce);
             
    }

    // Animaciones "Idle" y movimiento
    private void AnimationMovement()
    {
        // Animaci�n en movimiento
        if (_vertical != 0)
        {
            // Animaci�n correr
            if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            {

                _anim.SetBool("IsWalk", false);
                _anim.SetBool("IsRun", true);

            }

            // Animaci�n andar
            else
            {

                _anim.SetBool("IsWalk", true);
                _anim.SetBool("IsRun", false);

            }

            // Animaci�n hac�a detr�s
            if (_vertical < 0)
            {

                _anim.SetBool("IsBackwards", true);

            }

            // Animaci�n hac�a delante
            else
            {

                _anim.SetBool("IsBackwards", false);

            }
        }

        // Animaci�n "Idle"
        else
        {

            _anim.SetBool("IsWalk", false);
            _anim.SetBool("IsRun", false);
            _anim.SetBool("IsBackwards", false);

        }
    }

    // Animaci�n de salto
    private void AnimationJump()
    {

        if (!_isGrounded)
        {

            _anim.SetBool("IsJump", true);

        }

        else
        {
            _anim.SetBool("IsJump", false);
        }
    }
}
