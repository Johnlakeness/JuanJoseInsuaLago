using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTankHealth : MonoBehaviour
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

    [Header("Explosions")]
    [SerializeField]
    private ParticleSystem _smallExplosion;
    [SerializeField]
    private ParticleSystem _bigExplosion;

    private void Awake()
    {
  
        // Detiene el sistema de particulas
        _smallExplosion.Stop();
        _bigExplosion.Stop();

        // Asigna el máximo de vida a la vida actual
        _currentHealth = _maxHealth;

        // Asigna el máximo a la barra de vida
        _lifeBar.fillAmount = 1.0f;

    }

    private void OnCollisionEnter(Collision infoCollision)
    {
        
        // En caso que la bala del "Player" impacte con el enemigo
        if (infoCollision.collider.CompareTag("PlayerShell"))
        {

            // Reproducir sistema de particulas
            _smallExplosion.Play();

            // Restar a la vida actual, el daño asignado a la bala
            _currentHealth -= _damageBullet;

            // Recalcular la barra de vida en función a la vida actual
            _lifeBar.fillAmount = _currentHealth/_maxHealth;

            // Destruir la bala
            Destroy(infoCollision.gameObject);

            // En caso de que la vida del enemigo sea 0 o inferior
            if (_currentHealth <= 0.0f)
            {

                Death();

            }

        }

    }

    private void Death()
    {

        // Reproducir sistema de particulas
        _bigExplosion.Play();

        // Destruir el tanque enemigo
        Destroy(gameObject, 0.2f);

    }

}
