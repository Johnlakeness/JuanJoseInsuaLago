using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Rendering;
using UnityEngine;

public class XwingMovement : MonoBehaviour
{

    // Zona de variable globales
    [Header("Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _turnSpeed;

    [Header("Attack")]
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private Transform[] _posRotBulletsArray;

    private AudioSource _shootAudio;

    private void Awake()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        _shootAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Turning();
        Attack();

    }

    private void Movement()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // En el eje X, asignamos las teclas A y D
        // En el eje Y, asignamos las teclas W y S
        Vector3 direction = new Vector3(horizontal, 0.0f, vertical);
        
        transform.Translate(direction.normalized * _speed * Time.deltaTime);

    }

    private void Turning()
    {

        // Recoge el desplazamiento horizontal del ratón
        float xMouse = Input.GetAxis("Mouse X");

        // Recoge el desplazamiento vertical del ratón
        float yMouse = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(-yMouse, xMouse, 0.0f);

        transform.Rotate(rotation.normalized * _turnSpeed * Time.deltaTime);

    }

    private void Attack()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _shootAudio.Play();

            for (int i = 0; i < _posRotBulletsArray.Length; i++)
            {

                Instantiate(_bulletPrefab, _posRotBulletsArray[i].position, _posRotBulletsArray[i].rotation);

            }

        }

    }

}
