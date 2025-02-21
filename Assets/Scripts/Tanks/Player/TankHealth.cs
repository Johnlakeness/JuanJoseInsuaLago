using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    // Zona de variables globales
    [Header("Health")]
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _damageEnemyBullet;

    [Header("ProgressBar")]
    [SerializeField]
    private Image _lifeBar;

    [Header("Explosions")]
    [SerializeField]
    private ParticleSystem _bigExplosion;
    [SerializeField]
    private ParticleSystem _smallExplosion;

    [Header("Game Over")]
    [SerializeField]
    private GameManagerTanks _gameManager;


    private void Awake()
    {
        
        // Inicializa con la vida al máximo
        _currentHealth = _maxHealth;

        // Inicializa con barra de vida al máximo
        _lifeBar.fillAmount = 1.0f;

    }

    private void OnCollisionEnter(Collision infoCollision)
    {

        // Colisión de bala enemiga
        if (infoCollision.collider.CompareTag("EnemyShell"))
        {
            // Inicia sistema de particulas
            _smallExplosion.Play();

            // Daño de bala
            _currentHealth -= _damageEnemyBullet;

            // Actualización de la barra de vida
            _lifeBar.fillAmount = _currentHealth / _maxHealth;

            // Destruir bala después de colisión
            Destroy(infoCollision.collider.gameObject);

            // Muerte del "Player" en caso de la vida ser 0 o inferior
            if (_currentHealth <= 0.0f)
            {

                Death();

            }

        }

    }

    private void Death()
    {

        // Llamada al método "GameOver"
        _gameManager.GameOver();

        // Inicia sistema de particulas
        _bigExplosion.Play();

        // Destruye tanque del "Player"
        Destroy(gameObject, 0.5f);

    }

}
