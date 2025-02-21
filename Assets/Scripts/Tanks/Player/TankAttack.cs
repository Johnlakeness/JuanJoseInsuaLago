using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankAttack : MonoBehaviour
{

    // Zona de variables globales

    // Referencia al prefabricado de la bala
    [Header("Prefabs")]
    [SerializeField]
    private Rigidbody _shellPrefab;

    // Referencia al "gameObject" vacío que representa la posición de salida
    [SerializeField]
    private Transform _posShell;

    [SerializeField]
    private float _launchForce;

    [Header("Time")]
    // Tiempo transcurrido desde el último disparo
    [SerializeField]
    private float _timer;
    // Tiempo de recarga del disparo
    [SerializeField]
    private float _timeBetweenAttacks;

    // Indica si el taque puede atacar
    private bool _canAttack;

    [Header("ProgressBar")]
    [SerializeField]
    private Image _shellBar;

    private void Awake()
    {

        // Inicializa temporizador
        _timer = _timeBetweenAttacks;

        // Barra de progreso al 100%
        _shellBar.fillAmount = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {

        CounterTimer();
        InputPlayer();

    }

    private void CounterTimer()
    {

        // Aumento del contador
        _timer += Time.deltaTime;

        // Barra de progreso visual en función a la "carga"
        _shellBar.fillAmount = _timer / _timeBetweenAttacks;

        if (_timer >= _timeBetweenAttacks)
        {

            _canAttack = true;

        }

    }
 
    private void InputPlayer()
    {
        if (_canAttack)
        {

            // Asignación del "LMB"
            if (Input.GetMouseButtonDown(0))
            {

                Launch();

                // Reseteo del contador
                _timer = 0.0f;
                _canAttack= false;

            }

        }

    }

    private void Launch()
    {
        
        // Instancia Rigidbody de la bala
        Rigidbody cloneShellPrefab = Instantiate(_shellPrefab, 
        _posShell.position, _posShell.rotation);

        // Fuerza bala
        cloneShellPrefab.GetComponent<Rigidbody>().velocity = _posShell.forward
        * _launchForce;

    }

}
