using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    // Zona de variables globales
    private Transform _Target;

    // Velocidad de seguimiento
    private float _smoothing;

    // Distancia incial entre "target" y cámara
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {

        //"offset" es igual a posición cámara menos posición "player".
        _offset = transform.position - _Target.position;
        _smoothing = 5.0f;

    }

    // Update is called once per frame
    void Update()
    {
        
        // Posicionamiento y lerpeo
        Vector3 camPosition = _Target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, camPosition, _smoothing * Time.deltaTime);

    }
}
