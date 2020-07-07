using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighscore : MonoBehaviour
{
    public static bool resetHighscore = false;

    void Awake()
    {
        if (resetHighscore)
        {
            PlayerPrefs.SetInt("HighScore", 0);
            resetHighscore = false;
        }
    }


}
