using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerStarWars : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField]
    private GameObject _panelGameOver;
    [SerializeField]
    private GameObject _enemyAttack;
    [SerializeField]
    private GameObject _enemyManager;

    public void GameOver()
    {
        // Activar Panel "Game Over"
        _panelGameOver.SetActive(true);

        // Activar cursor
        Cursor.lockState = CursorLockMode.Confined;

    }

    // Método al que llamamos al pulsar el botón "Retry"

    public void LoadSceneLevel()
    {

        SceneManager.LoadScene(0);

    }
}
