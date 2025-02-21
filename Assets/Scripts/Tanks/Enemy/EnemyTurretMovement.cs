using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyTurretMovement : MonoBehaviour
{

    // Zona de variables globales
    [SerializeField]
    private GameObject _player;

    private void Awake()
    {

        // Busqueda jerarquica
        _player = GameObject.FindGameObjectWithTag("TankPlayer");

    }

    // Update is called once per frame
    void Update()
    {

        TurnTurret();

    }

    private void TurnTurret()
    {

        // Vector de rotación eje Y
        Vector3 positionTarget = new Vector3(_player.transform.position.x, 
                                 transform.position.y, _player.transform.position.z);

        // Mirar hacia "target"
        transform.LookAt(positionTarget);

    }

}
