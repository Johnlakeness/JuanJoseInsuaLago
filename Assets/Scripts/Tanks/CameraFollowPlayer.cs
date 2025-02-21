using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CameraFollowPlayer : MonoBehaviour
{

    // Zona de variables globales
    [Header("Targets")]
    [SerializeField]
    private Transform _target;

    [Header("Vectors")]
    // Velocidad de seguimiento de la cámara
    [SerializeField]
    private float _smoothing;
    // Distancia inicial entre cámara y "player"
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {

        _offset = transform.position - _target.position;

    }

    private void Update()
    {

        CameraPosition();

    }

    private void CameraPosition()
    {
        // Posición rotada del "Offset"
        Vector3 rotatedOffset = _target.rotation * _offset;

        // Posición a la que queremos mover la cámara
        Vector3 desiredPosition = _target.position + rotatedOffset;

        // Mover cámara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);

        // Mirar a target
        transform.LookAt(_target);

    }

}

