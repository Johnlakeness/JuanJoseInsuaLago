using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowJohnLemon : MonoBehaviour
{

    // Zona de variables globales
    public Transform Target;
    [Header("Verctors")]
    // Velocidad de seguimiento de la c�mara
    [SerializeField]
    private float _smoothing;
    // Distancia inicial entre c�mara y "player"
    [SerializeField]
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        
        _offset = transform.position - Target.position;

    }

    private void LateUpdate()
    {
        
        // Posici�n a la que queremos mover la c�mara
        Vector3 desiredPosition = Target.position + _offset;

        // Mover c�mara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);

    }

}
