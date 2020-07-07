using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float speed = ObstacleSpeed.getSpeed();
    private Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = ObstacleSpeed.getSpeed();
        float tempY = myRB.velocity.y;
        myRB.velocity = new Vector2(speed, tempY);
    }

    //Destroy player if obstacle hits player
    void OnCollisionEnter2D(Collision2D col)
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 1 && col.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().EndGame();
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);


        }

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
