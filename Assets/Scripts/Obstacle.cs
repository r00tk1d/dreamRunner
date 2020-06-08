using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //init speed, gets immediately changed by ObstacleSpawner
    private float speed = -1.0f;
    private Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }



    // Update is called once per frame
    void Update()
    {
        myRB.velocity = new Vector2(speed, 0);
    }

    //Destroy player if obstacle hits player
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            FindObjectOfType<GameManager>().EndGame();
        }

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
        FindObjectOfType<Score>().score++;
    }
}
