using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : Singleton<PauseMenu>
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;


    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }
    public void SetGameState()
    {
        if (!isGamePaused)
            Pause();
        else
            Resume();
    }

    public void Restart()
    {
        SetGameState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SetGameState();
        SceneManager.LoadScene(0);    
    }

    public void Quit()
    {
        Application.Quit();
    }

}
