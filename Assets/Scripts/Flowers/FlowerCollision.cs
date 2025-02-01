using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FlowerCollision : MonoBehaviour
{
    // Zona de variables globales

    [SerializeField]
    // Fisicas del "Zombie" al actuar con "Collider"
    private float _zombieCollisionSpeed = 10.0f,
                  _zombieCollisionForce = 5.0f;
    
    [SerializeField]
    // Tiempo que tarda "Destroy" en hacer efecto
    private float _zombieTimer = 1.5f;

    // Activa animación "Death"
    private bool _isDeath = false;

    private Rigidbody _rb;
    private Animator _anim;

    // Preiniciación de componentes
    private void Awake()
    {

        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {

        AnimationDeath();

    }

    // "Collider" para matar "Zombie"
    private void OnCollisionEnter(Collision infoCollision)
    {

        if (infoCollision.gameObject.CompareTag("Flowers"))
        {
            _isDeath = true;
            // Añadir valor a las físicas
            _rb.AddForce(-transform.forward * _zombieCollisionSpeed);
            _rb.AddForce(transform.up * _zombieCollisionForce);

            // Destruir Zombie
            Destroy(gameObject, _zombieTimer);

        }
    }
    
    // Método para activar animación de muerte de "Zombie"
    private void AnimationDeath()
    {
        if (_isDeath)
        {
            _anim.SetBool("IsDeath", true);
        }
    }
}
