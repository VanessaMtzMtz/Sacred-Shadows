using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;

    public Button playButton;
    public Button settingsButton;
    public Button exitButton;

    void Start()
    {
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
}
