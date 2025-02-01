using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Zona de variables globales
    [Header("Images")]
    [SerializeField]
    private Image _caughtImage;
    [SerializeField]
    private Image _wonImage;

    [Header("Fade")]
    // Duraci�n del "fade" de la imagen
    [SerializeField]
    private float _fadeDuration;
    // Tiempo de imagen en pantalla
    [SerializeField]
    private float _displayImageDuration;
    // Contador de tiempo
    private float _timer;

    // Saber si el "player" est� en la salida
    private bool _isPlayerAtExit;
    // Saber si han pillado al "player"
    public bool IsPlayerCaught;
    // Saber si se ejecuto m�todo para no repetirlo
    private bool hasPlayedWon;
    private bool hasPlayedCaught;

    [Header("Button")]
    [SerializeField]
    private GameObject _wonButton;

    [Header("Audio")]
    [SerializeField]
    private AudioClip _wonClip;
    [SerializeField]
    private AudioClip _caughtClip;
    private AudioSource _audioSource;

    [Header("Player")]
    [SerializeField]
    private GameObject _johnLemon;
    private JohnLemonMovement _movementScript;
    private Animator _johnLemonAnimator;
    private AudioSource _johnLemonAudioSource;

    private void Awake()
    {
        
        _audioSource = GetComponent<AudioSource>();
        _movementScript = _johnLemon.GetComponent<JohnLemonMovement>();
        _johnLemonAnimator = _johnLemon.GetComponent<Animator>();
        _johnLemonAudioSource = _johnLemon.GetComponent<AudioSource>();

        // Ocultar y bloquear cursor
        Cursor.lockState = CursorLockMode.Locked;

        hasPlayedWon = false;
        hasPlayedCaught = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (_isPlayerAtExit)
        {

            Won();

        }
        else if (IsPlayerCaught)
        {

            Caught();

        }

    }

    private void Won()
    {
        // Activar bot�n "Retry"
        _wonButton.SetActive(true);

        // Activar audio y evitar que se repita
        _audioSource.clip = _wonClip;
        if (!hasPlayedWon)
        {

            _audioSource.Play();
            hasPlayedWon = true;

        }

        _timer += Time.deltaTime;
        // Aumentar el canal Alfa progresivamente
        _wonImage.color = new Color(_wonImage.color.r, _wonImage.color.g, _wonImage.color.b, _timer / _fadeDuration);

        // "Delay" visualizaci�n del bot�n "retry"
        _wonButton.SetActive(true);

        // Activador cursor
        Cursor.lockState = CursorLockMode.Confined;

        // Destruir script movimiento y desactivar animaci�n y audio del "player"
        Destroy(_movementScript);
        _johnLemonAnimator.SetBool("IsWalking", false);
        _johnLemonAudioSource.Stop();

    }

    private void Caught()
    {

        // Activar audio y evitar que se repita
        _audioSource.clip = _caughtClip;
        if (!hasPlayedCaught)
        {

            _audioSource.Play();
            hasPlayedCaught = true;

        }

        _timer += Time.deltaTime;
        // Aumentar el canal Alfa progresivamente
        _caughtImage.color = new Color(_caughtImage.color.r, _caughtImage.color.g, _caughtImage.color.b, _timer / _fadeDuration);

        // Duraci�n de la imagen
        if (_timer > _fadeDuration + _displayImageDuration)
        {

            // Cargar escena
            SceneManager.LoadScene("JohnLemon");

        }

        // Destruir script movimiento y desactivar animaci�n y audio del "player"
        Destroy(_movementScript);
        _johnLemonAnimator.SetBool("IsWalking", false);
        _johnLemonAudioSource.Stop();

    }

    // "Player" en el final del nivel
    private void OnTriggerEnter(Collider infoAccess)
    {

        if (infoAccess.CompareTag("JohnLemon"))
        {

            _isPlayerAtExit = true;

        }

    }

    // M�todo al que llamamos al pulsar el bot�n "Retry"
    public void LoadSceneLevel()
    {

        // Cargar escena
        SceneManager.LoadScene("JohnLemon");

    }
}
