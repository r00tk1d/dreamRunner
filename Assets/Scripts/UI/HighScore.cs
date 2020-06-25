using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreText = GetComponent<Text>();
        HighScoreText.text = "Best: " + PlayerPrefs.GetInt("HighScore");
        
    }
}

