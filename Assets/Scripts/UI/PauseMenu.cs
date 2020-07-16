using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool sound = true;
    public Text SoundTxt;
    void Start()
    {
        pauseMenuUI.SetActive(false);
        if (sound)
        {
            SoundTxt.text = "Sound: On";
        }
        else
        {
            SoundTxt.text = "Sound: Off";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (PauseButton.newStatus)
        {
            PauseButton.newStatus = false;
            if (PauseButton.isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }

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

    public void LoadMenu()
    {
        PauseButton.Resume();
        SceneManager.LoadScene("StartMenuScene");
    }

    /**
    public void RestartGame()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Player")[0]);
        }
        PauseButton.Resume();
        FindObjectOfType<GameManager>().EndGame();
    }
    **/

    public void switchSound()
    {
        if (sound)
        {
            sound = false;
            SoundTxt.text = "Sound: Off";
            AudioListener.volume = 0f;
        }
        else
        {
            sound = true;
            SoundTxt.text = "Sound: On";
            AudioListener.volume = 1f;
        }

    }
}
