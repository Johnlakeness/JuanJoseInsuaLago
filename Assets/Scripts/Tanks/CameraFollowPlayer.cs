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
    // Velocidad de seguimiento de la c�mara
    [SerializeField]
    private float _smoothing;
    // Distancia inicial entre c�mara y "player"
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
        // Posici�n rotada del "Offset"
        Vector3 rotatedOffset = _target.rotation * _offset;

        // Posici�n a la que queremos mover la c�mara
        Vector3 desiredPosition = _target.position + rotatedOffset;

        // Mover c�mara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);

        // Mirar a target
        transform.LookAt(_target);

    }

}

