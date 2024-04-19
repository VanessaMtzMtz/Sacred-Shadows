using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float tiempoParaDestruir = 5f;

    void Start()
    {
        // Invocar el método de destrucción después de un tiempo determinado
        Invoke("DestruirObjeto", tiempoParaDestruir);
    }

    void DestruirObjeto()
    {
        // Destruir el objeto al que se le adjunta el script
        Destroy(gameObject);
    }
}
