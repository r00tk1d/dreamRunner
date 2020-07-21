using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    private bool newHighScore = false;
    public GameOver gameOverScreen;

    void Update()
    {
        if(!GameObject.FindWithTag("Player")&&!gameHasEnded){
            EndGame();
            gameHasEnded = true;
        }
    }

    public void EndGame ()
    {
        if(!gameHasEnded) {
            bool gameHasEnded = true;
            int currentScore = (int)FindObjectOfType<Score>().score;
            if(PlayerPrefs.GetInt("HighScore") < currentScore){
                PlayerPrefs.SetInt("HighScore", currentScore);
                newHighScore = true;
            }
            gameOverScreen.startGameOverAnimation(currentScore, newHighScore);
            PlayGamesController.PostToLeaderBoard((long)PlayerPrefs.GetInt("HighScore"));
        }
        
    }
}
