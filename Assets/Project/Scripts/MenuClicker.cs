using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClicker : MonoBehaviour
{
    public Button newGamebutton;
    public Button QuitButton;
    public Button controlButton;
    public Button creditsButton;
    public GameObject controlPanel;
    public GameObject creditsPanel;
    private string gameSceneName = "MapScene";
    // Start is called before the first frame update
    void Start()
    {
        newGamebutton.onClick.AddListener(LoadGameScene);
        QuitButton.onClick.AddListener(exitGame);
        controlButton.onClick.AddListener(showControls);
        creditsButton.onClick.AddListener(showCredits);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    void exitGame()
    {
        Application.Quit();
    }

    void showControls()
    {
        closeallPanels();
        controlPanel.SetActive(true);
    }

    void showCredits()
    {
        closeallPanels();
        controlPanel.SetActive(true);
    }

    void closeallPanels()
    {
        creditsPanel.SetActive(false);
        controlPanel.SetActive(false);
    }
}
