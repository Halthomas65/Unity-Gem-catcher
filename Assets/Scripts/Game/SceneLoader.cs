using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }


    public void NextLevel()
    {
        if (currentIndex >= 3)
        {
            SceneManager.LoadScene(0);
        }
        else
            SceneManager.LoadScene(currentIndex + 1);
    }

    public void PrevLevel()
    {
        if (currentIndex > 0)
        {
            SceneManager.LoadScene(currentIndex - 1);
        }
        else
        {
            Debug.Log("This is the lowest level");
        }
    }

    public void Reload()
    {
        // PlayerScript.playerScore = 0;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(currentIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
