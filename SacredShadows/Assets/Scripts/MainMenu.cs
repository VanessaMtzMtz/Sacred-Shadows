using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public List<GameObject> menu = new List<GameObject>();

    public GameObject selector;
    public GameObject mainPanel;
    public GameObject settingsPanel;

    public Button playButton;
    public Button settingsButton;
    public Button exitButton;

    private Button activeButton; // Botón activo seleccionado por el selector
    private int activeIndex = 0; // Índice del botón activo

    void Start()
    {
        // Asignar las funciones a los botones
        playButton.onClick.AddListener(PlayGame);
        settingsButton.onClick.AddListener(ShowOptions);
        exitButton.onClick.AddListener(QuitGame);
        ShowMain();
    }


    public void ShowOptions()
    {
        CleanPanels();
        settingsPanel.SetActive(true);
    }

    public void ShowMain()
    {
        CleanPanels();
        mainPanel.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }


    private void CleanPanels()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Función para manejar la navegación con el selector
    private void Navegar()
    {
        // Manejar la navegación hacia arriba con la tecla de flecha arriba
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            activeIndex = (activeIndex + menu.Count - 1) % menu.Count;
            UpdateSelector();
        }
        // Manejar la navegación hacia abajo con la tecla de flecha abajo
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            activeIndex = (activeIndex + 1) % menu.Count;
            UpdateSelector();
        }
    }

    // Función para manejar la acción al presionar Enter
    private void CheckEnter()
    {
        // Si se presiona Enter y hay un botón activo, ejecutar su acción
        if (Input.GetKeyDown(KeyCode.Return) && activeButton != null)
        {
            activeButton.onClick.Invoke();
        }
    }

    void Update()
    {
        Navegar();
        CheckEnter(); // Asegúrate de llamar a la función CheckEnter en Update
    }

    // Función para actualizar la posición del selector y el botón activo
    private void UpdateSelector()
    {
        selector.transform.position = menu[activeIndex].transform.position;
        activeButton = menu[activeIndex].GetComponent<Button>();
    }
}
