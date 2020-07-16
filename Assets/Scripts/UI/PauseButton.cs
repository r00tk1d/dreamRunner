using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// look PauseMenu for better understanding
public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isPaused = false;
    public static bool newStatus = false;
    private Button btn;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        newStatus = true;
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Update()
    {
        if (isPaused)
        {
            btn.GetComponentInChildren<Text>().text = "|>";
        }
        else
        {
            btn.GetComponentInChildren<Text>().text = "||";
        }

    }

    public static void Resume()
    {
        newStatus = true;
        isPaused = false;
        Time.timeScale = 1f;
        if (PauseMenu.sound)
        {
            AudioListener.volume = 1f;
        }

    }

    public static void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (PauseMenu.sound)
        {
            AudioListener.volume = 0.5f;
        }
    }
}