using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (PauseButton.isPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }


    public void Resume()
    {
        Debug.Log("Resume");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseButton.isPaused = false;
    }

    void Pause()
    {
        Debug.Log("Pause funct");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu(){
        //TODO LoadMenu
    }

    public void RestartGame(){
        FindObjectOfType<GameManager>().EndGame();
    }
}
