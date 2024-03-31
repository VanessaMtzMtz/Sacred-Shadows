using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HUDController : MonoBehaviour
{
    public GameObject HUDPanel;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;

    public Button pauseButton;
    public Button continueButton;
    public Button quitButton;
    public Button menuButton;

    public TextMeshProUGUI distanceText;
    private bool isGamePaused = false;
    private string textValue;

    // Start is called before the first frame update
    void Start()
    {
        pauseButton.onClick.AddListener(TogglePause);
        continueButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
        menuButton.onClick.AddListener(Menu);
        ShowHUD();
    }

   

    public void ShowHUD()
    {
        CleanPanels();
        HUDPanel.SetActive(true);
        Time.timeScale = 1.0f;
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void TogglePause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            Time.timeScale = 0f; // Pausar el tiempo del juego
            ShowPausePanel();
        }
        else
        {
            Time.timeScale = 1.0f; // Reanudar el tiempo del juego
            HidePausePanel();
        }
    }

    void ShowPausePanel()
    {
        CleanPanels();
        pausePanel.SetActive(true);
    }

    void HidePausePanel()
    {
        pausePanel.SetActive(false);
    }

    void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1.0f; // Asegurarse de que el tiempo est� despausado al volver al juego
        HidePausePanel();
        ShowHUD(); // Muestra el panel HUD nuevamente
    }

    void CleanPanels()
    {
        HUDPanel.SetActive(false);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
