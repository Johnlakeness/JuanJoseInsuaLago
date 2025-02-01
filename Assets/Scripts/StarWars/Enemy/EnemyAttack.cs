using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Zona de variables globales
    [Header("Attack")]
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private Transform[] _posRotBullet;
    private GameObject _player;
    [SerializeField]
    private float _timeBetweensBullets;

    private void Awake()
    {

        _player = GameObject.FindGameObjectWithTag("Xwing");
        InvokeRepeating("Attack", 1.0f, _timeBetweensBullets);

    }

    private void Attack()
    {

        for(int i = 0; i < _posRotBullet.Length; i++)
        {

            Instantiate(_bulletPrefab, _posRotBullet[i].position, _posRotBullet[i].rotation);

        }

    }
}
