using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{

    // Zona de variables globales
    [Header("Particulas")]
    [SerializeField]
    private ParticleSystem _explosionShell;

    [Header("Audio")]
    [SerializeField]
    private AudioClip _startClip;
    [SerializeField]
    private AudioClip _collisionClip;
    private AudioSource _audioSource;

    private Collider _coll;
    private Renderer _rend;

    private void Awake()
    {

        _audioSource = GetComponent<AudioSource>();

        _coll = GetComponent<Collider>();

        _rend = GetComponent<Renderer>();

    }

    private void Start()
    {

        // Inicia clip de audio
        _audioSource.clip = _startClip;
        _audioSource.Play();

    }

    private void OnCollisionEnter(Collision infoCollision)
    {
     
        // Desactivar "Collider" y "Renderer"
        _coll.enabled = false;
        _rend.enabled = false;

        // Reproducir Sistema de particulas
        _explosionShell.Play();

        // Reproducir Audio
        _audioSource.clip = _collisionClip;
        _audioSource.Play();

        // Destruir bala
        Destroy(gameObject, 0.5f);

    }

}
