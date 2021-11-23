using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Game Management
    [SerializeField] bool isRunning;
    public bool IsRunning
    {
        get { return isRunning; }
        protected set { isRunning = value; }
    }

    // UI elements
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject gameUIScreen;
    [SerializeField] GameObject settingsScreen;
    [SerializeField] GameObject creditsScreen;
    [SerializeField] GameObject instructionsScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject player;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        IsRunning = false;

        // Show the title screen
        ShowTitleScreen();
    }

    #region Menu Functions
    public void StartGame()
    {
        IsRunning = true;

        // Show the game UI
        HideAllUI();
        gameUIScreen.SetActive(true);
        player.SetActive(true);
    }

    public void ShowSettings()
    {
        HideAllUI();
        settingsScreen.SetActive(true);
        backButton.SetActive(true);
    }

    public void ShowInstructions()
    {
        HideAllUI();
        instructionsScreen.SetActive(true);
        backButton.SetActive(true);
    }

    public void ShowCredits()
    {
        HideAllUI();
        creditsScreen.SetActive(true);
        backButton.SetActive(true);
    }

    public void ShowTitleScreen()
    {
        HideAllUI();
        titleScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Application is exiting!");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    #endregion

    #region Game Events
    public void GameWon()
    {
        IsRunning = false;
        winScreen.SetActive(true);
    }

    public void GameLost()
    {
        IsRunning = false;
        loseScreen.SetActive(true);
    }
    #endregion

    #region Menu Utilities
    void HideAllUI()
    {
        titleScreen.SetActive(false);
        gameUIScreen.SetActive(false);
        settingsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        instructionsScreen.SetActive(false);
        backButton.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        player.SetActive(false);
    }
    #endregion
}
