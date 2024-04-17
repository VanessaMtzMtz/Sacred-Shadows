using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    public GameObject gameObjectToCheck;
    public GameObject gameObjectToDestroy;

    void Update()
    {
        // Verifica si el GameObject que se va a verificar está activo
        if (gameObjectToCheck.activeSelf)
        {
            // Destruye el otro GameObject si el primero está activo
            Destroy(gameObjectToDestroy);
        }
    }
}
