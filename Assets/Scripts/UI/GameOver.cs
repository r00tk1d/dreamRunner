using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text gameOverText;
    public Text newHighscoreText;
    public AudioSource highscoreSound;
    void Start()
    {
        gameOverUI.SetActive(false);
    }

    public void startGameOverAnimation(int currentScore, bool newHighscore)
    {
        gameOverUI.SetActive(true);
        if(newHighscore){
            gameOverText.color = Color.red;
            newHighscoreText.text = "New Highscore!";
        }
        StartCoroutine(upCounter(currentScore, newHighscore));
    }


    IEnumerator upCounter(int number, bool newHighscore)
    {
        float slowDown = 1 / (float)number;
        for (int i = 0; i <= number; i++)
        {
            if (i < number - 5)
            {
                yield return new WaitForSeconds(1 / (float)number);
                gameOverText.text = "Score: " + i;
            }
            else
            {
                yield return new WaitForSeconds(slowDown);
                slowDown += 0.03f;
                gameOverText.text = "Score: " + i;
            }

        }
        if(newHighscore){
            highscoreSound.Play();
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(1.4f);
        Restart();
    }

    void Restart()
    {
        Time.timeScale = 1.0f;
        ObstacleSpeed.setSpeed(DefValues.startSpeed);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
