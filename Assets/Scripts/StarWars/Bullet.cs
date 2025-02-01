using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Zona de variables globales
    [SerializeField]
    private float _speed;
    
    private float _timeDestroy = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, _timeDestroy);

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

    }
}
