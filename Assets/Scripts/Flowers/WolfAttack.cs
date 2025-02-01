using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WolfAttack : MonoBehaviour
{
    // Zona de variables globales
   
    // Objeto "Flower"
    [SerializeField]
    private GameObject _flowerObject;

    // Origen de "Flower"
    [SerializeField]
    private Transform _flowerOrigin;

    // Valores que afectan con "AddForce" del tiro de "Flower"
    [SerializeField]
    private float _flowerSpeed = 50.0f,
                  _flowerForce;

    // Tiempo que tarda en destruirse "Flower"
    [SerializeField]
    private float _DestroyTimer = 2.0f;

    // Variable para vincular "Animator"
    private Animator _anim;

    [SerializeField]
    // Variables de temporizador (0.5f en "_attackCooldown" porque el valor de
    // tiempo de la animación "Attack" en el "Animator" está ajustada a 0,5'')
    private float _attackCooldown = 0.5f,
                  _currentAttackCooldown = 0.0f;

    // Preiniciación de componentes
    private void Awake()
    {

        _anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // Temporizador para utilizar el método "AttackFlower"
        _currentAttackCooldown += Time.deltaTime;

        if(_currentAttackCooldown > _attackCooldown)
        {

            AttackFlower();

        }

        AttackAnimation();

    }

    private void AttackFlower()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            // Valores de posición y rotación en origen de instancia de "Flower"
            Vector3 flowerPosition = _flowerOrigin.transform.position;
            Quaternion flowerRotate = _flowerOrigin.transform.rotation;

            // Instanciación de "Flower"
            GameObject flowerClone = Instantiate(_flowerObject, flowerPosition, flowerRotate);

            // Llamada a componente rigidbody a la instancia
            Rigidbody _rb = flowerClone.GetComponent<Rigidbody>();

            // Añadir fuerza y velocidad al disparo de la instancia
            _rb.AddForce(transform.forward * _flowerSpeed);
            _rb.AddForce(transform.up * _flowerForce);

            // Destruir instancia
            Destroy(flowerClone, _DestroyTimer);

            // Retornar temporizador a 0
            _currentAttackCooldown = 0.0f;
        }
    }

    // Activación de la animación "Attack"
    private void AttackAnimation()
    {
        if (Input.GetMouseButtonDown(0))
        {

            _anim.SetBool("IsAttack", true);

        }
        
        else
        {

        _anim.SetBool("IsAttack", false);

        }
    }
}
