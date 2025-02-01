using UnityEngine;
using UnityEngine.UI;

public class XwingHealth : MonoBehaviour
{
    // Zona de variables globales
    [Header("Health")]
    // Salud máxima
    [SerializeField]
    private float _maxHealth;
    // Salud actual
    [SerializeField]
    private float _currentHealth;
    // Daño por bala enemiga
    [SerializeField]
    private float _damageEnemyBullet;

    [Header("ProgressBar")]
    // Imagen "Barra de vida"
    [SerializeField]
    private Image _lifeBar;

    [Header("Camera")]
    [SerializeField]
    private Camera _xwingCamera;

    [Header("Explosions")]
    [SerializeField]
    private ParticleSystem _bigExplosion;
    [SerializeField]
    private ParticleSystem _smallExplosion;

    [Header("Game Over")]
    [SerializeField]
    private GameManagerStarWars _gameManager;

    private void Awake()
    {
        // Pausar sistema de particulas
        _bigExplosion.Stop();
        _smallExplosion.Stop();

        // Valores iniciales vida
        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;

    }

    private void OnTriggerEnter(Collider infoAccess)
    {

        if (infoAccess.CompareTag("BulletEnemy"))
        {

            // Inciar Sistema de Particulas
            _smallExplosion.Play();

            // _currentHealth = _currentHealth - _damageEnemyBullet;
            _currentHealth -= _damageEnemyBullet;
            _lifeBar.fillAmount = _currentHealth / _maxHealth;
            Destroy(infoAccess.gameObject);

            if(_currentHealth <= 0.0f)
            {

                // Inciar Sistema de Particulas
                _bigExplosion.Play();

                Death();

            }

        }

    }

    private void Death()
    {

        _gameManager.GameOver();
        // Eliminar "parent" de cámara
        _xwingCamera.transform.SetParent(null);
        Destroy(gameObject, 0.4f);

    }
}
