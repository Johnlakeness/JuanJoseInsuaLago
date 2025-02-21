using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    // Zona de variales globales
    [Header("Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _turnSpeed;

    private float _horizontal,
                  _vertical;
    private Rigidbody _rb;

    [Header("Sound")]
    [SerializeField]
    private AudioClip _idleClip;
    [SerializeField]
    private AudioClip _drivingClip;

    private AudioSource _audioSource;

    private void Awake()
    {

        // Bloquea cursor
        Cursor.lockState = CursorLockMode.Locked;

        // Asigna componente "Rigidbody"
        _rb = GetComponent<Rigidbody>();

        // Asigna componete "AudioSource"
        _audioSource = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {

        Move();
        Turn();

    }

    // Update is called once per frame
    void Update()
    {
        
        InputsPlayer();
        AudioPlayer();

    }

    private void InputsPlayer()
    {

        // Asignación de valor a teclas de movimiento horizontal y vertical
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

    }

    private void Move()
    {

        // Valor del movimiento asignado a "Vector3"
        Vector3 direction = transform.forward * _vertical * _speed * Time.deltaTime;

        // Movimiento por "Rigidbody"
        _rb.MovePosition(transform.position + direction);

    }

    private void Turn()
    {

        //float turn = _horizontal * _turnSpeed * Time.deltaTime;

        // Valor de rotación asignado a "Quaternion"
        Quaternion turnRotation = Quaternion.Euler(0.0f, _horizontal, 0.0f);

        // Rotación por "Rigidbody"
        _rb.MoveRotation(transform.rotation * turnRotation);

    }

    private void AudioPlayer()
    {

        // El tanque se está movimento o está en rotación
        if (_vertical != 0.0f || _horizontal != 0.0f)
        {

            if (_audioSource.clip != _drivingClip)
            {

                // Asigna clip de audio a "AudioSource"
                _audioSource.clip = _drivingClip;

                // Reproduce clip de audio
                _audioSource.Play();

            }

        }

        // El tanque está parado
        else
        {

            if (_audioSource.clip != _idleClip)
            {
                // Asigna clip de audio a "AudioSource"
                _audioSource.clip = _idleClip;

                // Reproduce clip de audio
                _audioSource.Play();

            }

        }

    }

}
