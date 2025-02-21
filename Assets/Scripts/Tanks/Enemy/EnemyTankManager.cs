using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankManager : MonoBehaviour
{

    // Zona de variables globales
    [Header("Instatiate")]
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private Transform[] _posRotEnemy;
    [SerializeField]
    private float _timeBetweenEnemies;

    // Start is called before the first frame update
    void Start()
    {

        // Invoca cada "x" segundos el m�todo para crear tanques
        InvokeRepeating("CreateEnemies", 0.0f, _timeBetweenEnemies);

    }

    private void CreateEnemies()
    {

        // Asignaci�n aleatoria de n�meros del "Array"
        int n = Random.Range(0, _posRotEnemy.Length);

        // Instanciaci�n de enemigos en uno de los puntos del "Array" de posiciciones
        Instantiate(_enemyPrefab, _posRotEnemy[n].position, _posRotEnemy[n].rotation);

    }

}
