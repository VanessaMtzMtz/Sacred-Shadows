using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

<<<<<<< Updated upstream
=======
    private bool isBackpackPanelActive = false;
    private bool isEstadosPanelActive = false;

    public TextMeshProUGUI warningTxt;

    private float tensionIncrementRate = 3f; // Ajusta la velocidad de aumento de la tensión
    private float tiempoTranscurridoDesdeUltimaActualizacion = 0f;
    private float tiempoDeActualizacion = 20f; // Intervalo de tiempo para aumentar el hambre y la sed (en segundos)
    private float tiempoTranscurrido = 0f; // Tiempo transcurrido desde la última disminución de la batería
    private float intervaloBateria = 2f; // Intervalo de tiempo para disminuir la batería (en segundos)
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        hudController = FindObjectOfType<HUDController>();
    }

    // Update is called once per frame
    void Update()
    {
        barraHambre.fillAmount = (float)hambreActual / hambreMaxima;
        barraSed.fillAmount = (float)sedActual / sedMaxima;
        barraTension.fillAmount = (float)tensionActual / tensionMaxima;
        barraAltura.fillAmount = alturaActual / alturaMaxima;
<<<<<<< Updated upstream
        barraBateria.fillAmount = bateriaActual / bateriaMaxima;
=======
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
            ActualizarBarraHambre();
            ActualizarBarraSed();

            // Comprobar si hambreActual es mayor o igual a 80 y aumentar tensionActual
            if (hambreActual >= 80)
            {
                tensionActual += 20;
            }

            // Comprobar si sedActual es mayor o igual a 80 y aumentar tensionActual
            if (sedActual >= 80)
            {
                tensionActual += 20;
            }

            // Asegurarse de que tensionActual no exceda el máximo
            tensionActual = Mathf.Min(tensionActual, tensionMaxima);

            // Reiniciar el temporizador
            tiempoTranscurridoDesdeUltimaActualizacion = 0f;
        }
>>>>>>> Stashed changes

        // Verificar si se ha presionado la tecla para activar/desactivar el panel Mochila
        if (Input.GetKeyDown(mochila))
        {
            // Si el panel está activo, lo desactivamos. Si está desactivado, lo activamos.
            backpackPanel.SetActive(!backpackPanel.activeSelf);
            estadosPanel.SetActive(false);

            // Actualizar el estado de los paneles
            if (backpackPanel.activeSelf)
            {
                ActivateBackpackPanel();
            }
            else
            {
                DeactivateBackpackPanel();
            }
        }

        // Verificar si se ha presionado la tecla para activar/desactivar el panel Estados
        if (Input.GetKeyDown(estados))
        {
            // Si el panel está activo, lo desactivamos. Si está desactivado, lo activamos.
            estadosPanel.SetActive(!estadosPanel.activeSelf);
            backpackPanel.SetActive(false);

            // Actualizar el estado de los paneles
            if (estadosPanel.activeSelf)
            {
                ActivateEstadosPanel();
            }
            else
            {
                DeactivateEstadosPanel();
            }
        }

<<<<<<< Updated upstream
        if (tensionActual <= 0)//El usuario pierde
=======
        // Debug para verificar el estado de los paneles
        Debug.Log("Backpack Panel Activo: " + isBackpackPanelActive);
        Debug.Log("Estados Panel Activo: " + isEstadosPanelActive);

        // Verificar si al menos uno de los paneles está activo y aumentar o reducir la tensión en consecuencia
        if (isBackpackPanelActive || isEstadosPanelActive)
        {
            // Si al menos uno de los paneles está activo, aumentamos la tensión
            tensionActual += Mathf.RoundToInt(tensionIncrementRate * Time.deltaTime);
        }
        else
        {
            // Si ambos paneles están desactivados, reducimos la tensión a la mitad del incremento
            tensionActual -= Mathf.RoundToInt(tensionIncrementRate * Time.deltaTime * 0.5f);
        }



        // Debug para verificar la tensión después de ajustarla
        Debug.Log("Tensión Actual después de ajuste: " + tensionActual);

        // Asegurarse de que la barra de tensión esté dentro del rango
        tensionActual = Mathf.Clamp(tensionActual, 0, tensionMaxima);


        if (tensionActual == 100)//El usuario pierde
>>>>>>> Stashed changes
        {
            backpackPanel.SetActive(false);
            estadosPanel.SetActive(false);
            hudController.gameOverPanel.SetActive(true);
        }

        if (tensionActual >= 70)//Activamos sonido
        {
            SFXManager.Instance.PlayFear();
        }

        // Debug para verificar si tensionActual cambia después de los cálculos
        Debug.Log("Valor de tensionActual después de cálculos (userController): " + tensionActual);


        // Actualizar la barra de tensión
        barraTension.fillAmount = (float)tensionActual / tensionMaxima;
    }
<<<<<<< Updated upstream
=======

    // Función para disminuir la batería
    void DisminuirBateria()
    {
        if (bateriaActual > 0) // Asegurarse de que la batería no esté vacía
        {
            bateriaActual--; // Disminuir la batería en un punto
            Debug.Log(bateriaActual);
        }

        if (bateriaActual == 0)//Si la bateria se agota el miedo crece
        {
            tensionActual += 35;
        }

        if (bateriaActual <= 20)//Si la bateria se agota el miedo crece
        {
            warningTxt.text = "¡TUS BATERIAS SE AGOTAN! Busca una fogata urgentemente";
        }
    }

    // Funciones para activar/desactivar los paneles
    public void ActivateBackpackPanel()
    {
        isBackpackPanelActive = true;
    }

    public void DeactivateBackpackPanel()
    {
        isBackpackPanelActive = false;
    }

    public void ActivateEstadosPanel()
    {
        isEstadosPanelActive = true;
    }

    public void DeactivateEstadosPanel()
    {
        isEstadosPanelActive = false;
    }
>>>>>>> Stashed changes
}
