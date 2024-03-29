using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userController : MonoBehaviour
{
    public HUDController hudController;
    public GameObject backpackPanel;
    public GameObject estadosPanel;

    public KeyCode mochila = KeyCode.Q;
    public KeyCode estados = KeyCode.E;

    public Image barraTension;
    public Image barraHambre;
    public Image barraAltura;
    public Image barraBateria;

    private float tensionActual;
    private float tensionMaxima;
    private float hambreActual;
    private float hambreMaxima;
    private float alturaActual;
    private float alturaMaxima;
    private float bateriaActual;
    private float bateriaMaxima;


    // Start is called before the first frame update
    void Start()
    {
        hudController = FindObjectOfType<HUDController>();
        //hudController.SetLifes(currentHealth);

    }

    // Update is called once per frame
    void Update()
    {
        barraTension.fillAmount = tensionActual / tensionMaxima;
        barraHambre.fillAmount = hambreActual / hambreMaxima;
        barraAltura.fillAmount = alturaActual / alturaMaxima;
        barraBateria.fillAmount = bateriaActual / bateriaMaxima;

        // Verificar si se ha presionado la tecla para activar/desactivar el panel Mochila
        if (Input.GetKeyDown(mochila))
        {
            // Si el panel está activo, lo desactivamos. Si está desactivado, lo activamos.
            backpackPanel.SetActive(!backpackPanel.activeSelf);
        }

        // Verificar si se ha presionado la tecla para activar/desactivar el panel Estados
        if (Input.GetKeyDown(estados))
        {
            // Si el panel está activo, lo desactivamos. Si está desactivado, lo activamos.
            estadosPanel.SetActive(!estadosPanel.activeSelf);
        }


        if (tensionActual <= 0)
        {
           /* anim.SetTrigger("Morir");
            textValue = "Moriste";
            textElement.text = textValue;*/
        }
    }
}
