using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isPaused = false;
    private Button btn;
    void Start()
    {
        btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        if(isPaused){
            isPaused = false;
            btn.GetComponentInChildren<Text>().text = "||";
            Time.timeScale = 1f;
        }
        else{
            isPaused = true;
            btn.GetComponentInChildren<Text>().text = "|>";
            Time.timeScale = 0f;
        }
        Debug.Log(isPaused);
    }
}
