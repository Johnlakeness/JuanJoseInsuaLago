using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankMovement : MonoBehaviour
{

    // Zona de variables globales
    [SerializeField]
    private GameObject _player;

    private NavMeshAgent _agent;

    [Header("Sound")]
    [SerializeField]
    private AudioClip _idleClip;
    [SerializeField]
    private AudioClip _drivingClip;

    private AudioSource _audioSource;

    private Vector3 _previousPosition;

    private void Awake()
    {

        // Busqueda jerarquica
        _player = GameObject.FindGameObjectWithTag("TankPlayer");

        // Componente Agente "Mesh"
        _agent = GetComponent<NavMeshAgent>();

        // Componente Audio
        _audioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {

        _previousPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(_player == null)
        {

            return;

        }

        GetPlayer();
        Audio();

    }

    private void GetPlayer()
    {

        // Vincula el agente al "Player" ("Target")
        _agent.SetDestination(_player.transform.position);

    }

    private void Audio()
    {

        Vector3 currentPosition = transform.position;

        // Magnitud entre posición anterior y actual
        float positionMagnitude = (currentPosition - _previousPosition).magnitude;

        // Audio en movimiento
        if (positionMagnitude != 0.0f)
        {

            if (_audioSource.clip != _drivingClip)
            {

                _audioSource.clip = _drivingClip;
                _audioSource.Play();

            }

        }

        // Audio "Idle"
        else
        {

            if (_audioSource.clip != _idleClip)
            {

                _audioSource.clip = _idleClip;
                _audioSource.Play();

            }

        }

        // Actualizar posición
        _previousPosition = currentPosition; 

    }

}
