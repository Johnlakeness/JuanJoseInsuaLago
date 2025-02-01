using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour
{
    // Zona de variables globales

    [SerializeField]
    // Velocidad movimiento y rotación
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

    // Preiniciación de componentes
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

    // Método movimiento (W/S)
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

    // Método rotación (A/D)
    private void Rotate()
    {

        transform.Rotate(Vector3.up * _horizontal * _turnSpeed  * Time.deltaTime);

    }



    // Raycast desde posición de personaje hacia suelo
    private void IsGround()
    {
        // Valor de origen y dirección de "_ray"
        _ray.origin = transform.position;
        _ray.direction = -transform.up;

        // Si está tocando el suelo
        if (Physics.Raycast(_ray.origin, _ray.direction, _rayLenght, _groundMask))
        {

            _isGrounded = true;

        }

        // Si está en el aire
        else
        {

            _isGrounded = false;

        }

    }

    // Verificación del salto
    private void CanJump()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {

            _canPlayerJump = true;

        }

    }

    // Añadir valor al Rigidbody para saltar
    private void Jump()
    {

        _rb.AddForce(transform.up * _jumpForce);
             
    }

    // Animaciones "Idle" y movimiento
    private void AnimationMovement()
    {
        // Animación en movimiento
        if (_vertical != 0)
        {
            // Animación correr
            if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            {

                _anim.SetBool("IsWalk", false);
                _anim.SetBool("IsRun", true);

            }

            // Animación andar
            else
            {

                _anim.SetBool("IsWalk", true);
                _anim.SetBool("IsRun", false);

            }

            // Animación hacía detrás
            if (_vertical < 0)
            {

                _anim.SetBool("IsBackwards", true);

            }

            // Animación hacía delante
            else
            {

                _anim.SetBool("IsBackwards", false);

            }
        }

        // Animación "Idle"
        else
        {

            _anim.SetBool("IsWalk", false);
            _anim.SetBool("IsRun", false);
            _anim.SetBool("IsBackwards", false);

        }
    }

    // Animación de salto
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
