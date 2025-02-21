using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTanks : MonoBehaviour
{

    // Zona de variables globales
    [Header("GameOver")]
    [SerializeField]
    private GameObject _panelGameOver;
    [SerializeField]
    private EnemyTankManager _enemyManager;

    public void GameOver()
    {

        // Activar el panel de "Game Over"
        _panelGameOver.SetActive(true);

        /* Cambi� el "_enemyManager.enabled = false;" por un "Destroy" debido
         * a que, con el primero nombrado, se segu�an generando instanciacias 
         * de tanques despu�s de llamar al "Game Over" */
        Destroy(_enemyManager);

        // Activar cursor
        Cursor.lockState = CursorLockMode.Confined;

    }

    public void LoadSceneLevel()
    {

        // Recarga escena "Tanks"
        SceneManager.LoadScene(2);

    }

}
