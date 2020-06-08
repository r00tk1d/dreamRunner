using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public void EndGame ()
    {
        if(gameHasEnded == false) {
            bool gameHasEnded = true;
            int currentScore = (int)FindObjectOfType<Score>().score;
            if(PlayerPrefs.GetInt("HighScore") < currentScore){
                PlayerPrefs.SetInt("HighScore", currentScore);
            }
            Restart();
        }
        
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
