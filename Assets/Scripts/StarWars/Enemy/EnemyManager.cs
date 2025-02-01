using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    // Zona de variables globales
    [Header("Instantiate")]
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private Transform[] _posRotEnemy;
    [SerializeField]
    private float _timeBetweenEnemies;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("CreateEnemies", _timeBetweenEnemies, _timeBetweenEnemies);

    }

    private void CreateEnemies()
    {

        int n = Random.Range(0, _posRotEnemy.Length);

        Instantiate(_enemyPrefab, _posRotEnemy[n].position, _posRotEnemy[n].rotation);

    }
}
