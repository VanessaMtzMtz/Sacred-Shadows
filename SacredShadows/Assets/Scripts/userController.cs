using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userController : MonoBehaviour
{
    public HUDController hudController;
    public GameObject backpackPanel;
    public GameObject estadosPanel;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;

    public KeyCode mochila = KeyCode.Q;
    public KeyCode estados = KeyCode.E;

    public Image barraTension;
    public Image barraHambre;
    public Image barraAltura;
    public Image barraBateria;
    public Image barraSed;

    public int tensionActual = 50;
    public int tensionMaxima = 100;
    public int hambreActual = 10;
    public int hambreMaxima = 100;
    public int sedActual = 10;
    public int sedMaxima = 100;
    public int alturaActual = 0;
    public int alturaMaxima = 100;
    public int bateriaActual = 100;
    public int bateriaMaxima = 100;

    private float tiempoTranscurridoDesdeUltimaActualizacion = 0f;
    private float tiempoDeActualizacion = 20f; // Intervalo de tiempo para aumentar el hambre y la sed (en segundos)
    private float tiempoTranscurrido = 0f; // Tiempo transcurrido desde la última disminución de la batería
    private float intervaloBateria = 5f; // Intervalo de tiempo para disminuir la batería (en segundos)

    // Start is called before the first frame update
    void Start()
    {
        hudController = FindObjectOfType<HUDController>();
        ActualizarBarraSed(); // Llama a la función para actualizar la barra de sed al inicio
    }

    public void ActualizarBarraHambre()
    {
        barraHambre.fillAmount = (float)hambreActual / hambreMaxima;
    }

    public void ActualizarBarraSed()
    {
        barraSed.fillAmount = (float)sedActual / sedMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarBarraHambre();
        ActualizarBarraSed();
        barraTension.fillAmount = (float)tensionActual / tensionMaxima;
        barraAltura.fillAmount = alturaActual / alturaMaxima;
        barraBateria.fillAmount = (float)bateriaActual / bateriaMaxima;

        // Verificar si ha pasado medio minuto para disminuir la batería
        tiempoTranscurrido += Time.deltaTime; // Aumentar el tiempo transcurrido en cada fotograma
        if (tiempoTranscurrido >= intervaloBateria)
        {
            DisminuirBateria(); // Disminuir la batería si ha pasado el intervalo
            tiempoTranscurrido = 0f; // Reiniciar el tiempo transcurrido
        }

        
        // Aumentar el hambre y la sed cada minuto
        tiempoTranscurridoDesdeUltimaActualizacion += Time.deltaTime; // Sumar el tiempo transcurrido en cada fotograma
        if (tiempoTranscurridoDesdeUltimaActualizacion >= tiempoDeActualizacion)
        {
            hambreActual += 5;
            sedActual += 5;

            // Asegurarse de que el valor no exceda el máximo
            hambreActual = Mathf.Min(hambreActual, hambreMaxima);
            sedActual = Mathf.Min(sedActual, sedMaxima);
            ActualizarBarraSed();
            // Reiniciar el temporizador
            tiempoTranscurridoDesdeUltimaActualizacion = 0f;
        }


        // Verificar si se ha presionado la tecla para activar/desactivar el panel Mochila
        if (Input.GetKeyDown(mochila))
        {
            // Si el panel está activo, lo desactivamos. Si está desactivado, lo activamos.
            backpackPanel.SetActive(!backpackPanel.activeSelf);
            estadosPanel.SetActive(false);
        }

        // Verificar si se ha presionado la tecla para activar/desactivar el panel Estados
        if (Input.GetKeyDown(estados))
        {
            // Si el panel está activo, lo desactivamos. Si está desactivado, lo activamos.
            estadosPanel.SetActive(!estadosPanel.activeSelf);
            backpackPanel.SetActive(false);
        }

        if (tensionActual == 100)//El usuario pierde
        {
            hudController.gameOverPanel.SetActive(true);
        }
    }

    // Función para disminuir la batería
    void DisminuirBateria()
    {
        if (bateriaActual > 0) // Asegurarse de que la batería no esté vacía
        {
            bateriaActual--; // Disminuir la batería en un punto
        }

        if (bateriaActual == 0)//Si la bateria se agota el miedo crece
        {
            tensionActual += 35;
        }
    }
}

