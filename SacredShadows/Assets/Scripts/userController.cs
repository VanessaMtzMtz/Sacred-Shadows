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
        barraBateria.fillAmount = bateriaActual / bateriaMaxima;

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

        if (tensionActual <= 0)
        {
            hudController.gameOverPanel.SetActive(true);
        }
    }
}
