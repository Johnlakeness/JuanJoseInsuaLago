using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CanvasEnemy : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
        // Mira hacía la cámara de la escena que tenga la etiqueta "MainCamera"
        transform.LookAt(Camera.main.transform.position);

    }
}
