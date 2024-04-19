using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reduceLight : MonoBehaviour
{
    public Light spotlight;
    public float duracion = 10f;

    void Start()
    {
        StartCoroutine(DisminuirIntensidadGradualmente());
    }

    IEnumerator DisminuirIntensidadGradualmente()
    {
        // Guardar la intensidad inicial del spotlight
        float intensidadInicial = spotlight.intensity;

        // Calcular el cambio de intensidad por segundo
        float cambioPorSegundo = intensidadInicial / duracion;

        // Bucle para disminuir gradualmente la intensidad
        while (spotlight.intensity > 0f)
        {
            // Reducir la intensidad gradualmente
            spotlight.intensity -= cambioPorSegundo * Time.deltaTime;

            // Esperar un frame
            yield return null;
        }

        // Asegurarse de que la intensidad sea 0 al final
        spotlight.intensity = 0f;
    }
}
