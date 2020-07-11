using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float score = 0;
    //private static int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        int bonusShips = GameObject.FindGameObjectsWithTag("bonusShip").Length;
        score += Time.deltaTime * (bonusShips + 1);
        scoreText.text = "" + (int)score;
    }
}
