using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public SceneLoader sceneLoader;

    // TODO: Change this when add new levels
    // public TextMeshProUGUI gameOverText;
    // public GameObject gameOverPanel;
    // public GameObject levelCompletePanel;
    // public GameObject endText;
    // public int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        // levelCompletePanel.SetActive(false);
        // gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Pause the game after pressing Escape
        bool pause = Input.GetKeyDown(KeyCode.Escape);
        if (pause)
        {
            if (Time.timeScale != 0)    // pause
                PauseGame();
            else    // resume
            {
                ResumeGame();
            }
        }

        if (Time.timeScale == 0)
        {
            // Resume
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResumeGame();
            }

            // Reload/Retry
            if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.Return))
            {
                sceneLoader.Reload();
            }

            // Main menu
            if (Input.GetKeyDown(KeyCode.M))
            {
                sceneLoader.MainMenu();
            }

            // Quit
            if (Input.GetKeyDown(KeyCode.Q))
            {
                QuitGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    // public void GameOver()
    // {
    //     gameOverText.text = "Game Over!\nScore: " + ScoreManager.score;
    //     gameOverPanel.SetActive(true);
    //     pauseButton.SetActive(false);
    //     // Time.timeScale = 0;
    // }

    // public IEnumerator LevelComplete()
    // {
    //     yield return new WaitForSeconds(2);

    //     levelCompletePanel.SetActive(true);
    //     pauseButton.SetActive(false);
    //     Time.timeScale = 0;
    // }

    public void QuitGame()
    {
        Application.Quit();
    }
}
