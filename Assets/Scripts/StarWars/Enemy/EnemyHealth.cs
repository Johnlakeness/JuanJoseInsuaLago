using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    // Zona de variables globales
    [Header("Health")]
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _damageBullet;

    [Header("HealthBar")]
    [SerializeField]
    private Image _lifeBar;

    [Header("Explosion")]
    [SerializeField]
    private ParticleSystem _smallExplosion;
    [SerializeField]
    private ParticleSystem _bigExplosion;

    private void Awake()
    {
        
        _smallExplosion.Stop();
        _bigExplosion.Stop();

        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;

    }

    private void OnTriggerEnter(Collider infoAccess)
    {
       
        if (infoAccess.CompareTag("BulletPlayer"))
        {

            _smallExplosion.Play();
            _currentHealth -= _damageBullet;
            _lifeBar.fillAmount = _currentHealth/_maxHealth;
            Destroy(infoAccess.gameObject);

            if (_currentHealth <= 0.0f)
            {

                Death();

            }

        }

    }

    private void Death()
    {

        _bigExplosion.Play();
        Destroy(gameObject, 1.0f);

    }
}
