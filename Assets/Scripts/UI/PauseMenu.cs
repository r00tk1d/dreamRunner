using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
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
        pauseMenuUI.SetActive(false);
        PauseButton.Resume();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
    }

    public void LoadMenu(){
        PauseButton.Resume();
        SceneManager.LoadScene("StartMenuScene");
    }

    public void RestartGame(){
        FindObjectOfType<GameManager>().EndGame();
        PauseButton.Resume();
    }
}
