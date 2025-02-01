using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class JohnLemonMovement : MonoBehaviour
{

    // Zona de variables globales
    [Header("Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _turnSpeed;
    // Guarda la dirección del movimiento
    [SerializeField]
    private Vector3 _direction;
    private float _horizontal, 
                  _vertical;

    private Rigidbody _rb;
    private Animator _anim;
    private AudioSource _audioSource;


    private void Awake()
    {

        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();  
        _audioSource = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {

        Rotation();

    }

    private void OnAnimatorMove()
    {

        _rb.MovePosition(transform.position + (_direction * _anim.deltaPosition.magnitude));

    }
    // Update is called once per frame
    void Update()
    {

        InputsPlayer();
        IsAnimate();
        AudioSteps();

    }

    private void InputsPlayer()
    {

        // Teclas A y D, así como flechas < y >
        _horizontal = Input.GetAxis("Horizontal");
        // Teclas W y S, así como flechas ^ y v
        _vertical = Input.GetAxis("Vertical");
        // Dirección en Axis X, Y, Z
        _direction = new Vector3(_horizontal, 0.0f, _vertical);
        // Nnormalizar Vector
        _direction.Normalize();

    }

    private void IsAnimate()
    {

        if(_horizontal != 0.0f || _vertical != 0.0f)
        {

            _anim.SetBool("IsWalking", true);

        }
        else
        {

            _anim.SetBool("IsWalking", false);

        }

    }

    private void Rotation()
    {
        
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _direction, _turnSpeed * Time.deltaTime, 0.0f);

        // Devuelve del Vector3 un Quaternion
        Quaternion rotation = Quaternion.LookRotation(desiredForward);
        _rb.MoveRotation(rotation);

    }

    private void AudioSteps()
    {

        if(_horizontal != 0 || _vertical != 0)
        {

            if(_audioSource.isPlaying == false)
            {

                _audioSource.Play();

            }


        }
        else
        {

            _audioSource.Stop();

        }

    }
}
