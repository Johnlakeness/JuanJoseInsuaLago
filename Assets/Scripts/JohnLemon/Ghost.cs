using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    // Zona de variables globales
    [Header("WayPoints")]
    // "Array" de posiciones para patrulla
    [SerializeField]
    private Transform[] _positionsArray;
    [SerializeField]
    private float _speed;
    // Almacenar posición a la que se dirige
    private Vector3 _posToGo;
    // Índice para controlar en qué posición del "array" está el fantasma
    private int _i;
    private Ray _ray;
    private RaycastHit _hit;

    public GameManager GameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        
        _i = 0;
        _posToGo = _positionsArray[_i].position;

    }

    private void FixedUpdate()
    {

        DetectionJohnLemon();

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        ChangePositions();
        Rotate();

    }

    private void Move()
    {

        transform.position = Vector3.MoveTowards(transform.position, _posToGo, _speed * Time.deltaTime);

    }

    private void ChangePositions()
    {

        // Si el fantasma ha llegado a destino
        if(Vector3.Distance(transform.position, _posToGo) <= Mathf.Epsilon)
        {

            // Compobar si estoy en la última casilla del "array" (Elemento 1)
            if(_i == _positionsArray.Length - 1)
            {

                // Retornar a casilla inicial del "array"
                _i = 0;

            }
            else
            {

                _i++;

            }

            _posToGo = _positionsArray[_i].position;

        }

    }

    private void Rotate()
    {

        transform.LookAt(_posToGo);

    }

    private void DetectionJohnLemon()
    {

        /* Subir el origen del "ray" 1m en el eje y con respecto al punto de
        pivote del objeto */
        _ray.origin = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        _ray.direction = transform.forward;

        if(Physics.Raycast(_ray, out _hit))
        {

            if (_hit.collider.CompareTag("JohnLemon"))
            {

                GameManagerScript.IsPlayerCaught = true;

            }

        }

    }

}
