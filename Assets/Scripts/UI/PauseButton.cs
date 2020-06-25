using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// look PauseMenu for better understanding
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
            Time.timeScale = 1f;
        }
        else{
            isPaused = true;
            Time.timeScale = 0f;
        }
    }

    void Update(){
        if(isPaused){
            btn.GetComponentInChildren<Text>().text = "|>";
        } else {
            btn.GetComponentInChildren<Text>().text = "||";
        }
        
    }
}