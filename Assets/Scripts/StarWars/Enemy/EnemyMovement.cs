using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // Zona de variables globales
    [Header("Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _distanceToPlayer;
    private GameObject _player;

    private void Awake()
    {

        _player = GameObject.FindGameObjectWithTag("Xwing");

    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        FollowPlayer();

    }

    private void Movement()
    {

        // Si no encuentras al "gameObject" Xwing, no hagas nada
        if (_player == null)
        {

            return;

        }

        transform.LookAt(_player.transform.position);

    }

    private void FollowPlayer()
    {

        // Calculo distancia entre enemigo y "player" (en metros)
        float distance = Vector3.Distance(transform.position, _player.transform.position);

        if (distance > _distanceToPlayer)

        {

            // Movemos a la nave enemigo con el método "Translate" indicándole:
            // El eje en el que voy a mover y a qué velocidad transformada a m/s
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        }

    }

}
