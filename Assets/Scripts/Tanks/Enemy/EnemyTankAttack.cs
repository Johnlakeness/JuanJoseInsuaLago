using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.WSA;

public class EnemyTankAttack : MonoBehaviour
{

    // Zona de variables globales
    [Header("Time")]
    [SerializeField]
    private float _timer;
    [SerializeField]
    private float _timeBetweenAttacks;

    private bool _canAttack;

    [Header("Prefab")]
    [SerializeField]
    private Rigidbody _shellEnemyPrefab;
    [SerializeField]
    private Transform _posShell;
    [SerializeField]
    private float _launchForce;
    [SerializeField]
    private float _factorLaunchFactor;
    [SerializeField]
    private GameObject _turretTank;

    [Header("Raycast")]
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField]
    private float _distance;
    [SerializeField]
    private float _distanceAttack;



    private void Awake()
    {
        
        // Inicializa sin poder atacar
        _canAttack = false;

    }

    private void FixedUpdate()
    {
        
        // En caso de poder atacar
        if(_canAttack)
        {

            Launch();
            _canAttack = false;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
        CountTimer();

    }

    private void CountTimer()
    {

        // Origen y dirección "raycast"
        _ray.origin = _turretTank.transform.position;
        _ray.direction = _turretTank.transform.forward;

        // Contador
        _timer += Time.deltaTime;

        if (Physics.Raycast(_ray, out _hit))
        {

            /* Comparativa de etiquetas para saber si la bala ha colionado con el
               "Player" y si el contador ha superado el tiempo entre balas */
            if (_hit.collider.CompareTag("TankPlayer") 
                && _timer >= _timeBetweenAttacks)
            {

                /*  Se saca la distancia que hay desde el tanque "player" 
                    hasta el enemigo */
                _distance = _hit.distance;

                if(_distance <= _distanceAttack)
                {

                    _canAttack = true;

                }

            }

        }

    }

    private void Launch()
    {

        // Valor de la fuerza en función a la distacia con el "Player"
        float _launchForceFinal = _launchForce * _distance * _factorLaunchFactor;

        // Instanciación de la bala
        Rigidbody cloneShellPrefab = Instantiate    (_shellEnemyPrefab, 
                                     _posShell.position, _posShell.rotation);

        // Fuerza de lanzamiento de la bala
        cloneShellPrefab.velocity = _posShell.forward * _launchForceFinal;
        
        // Retorna el contador a 0
        _timer = 0.0f;

    }

}
