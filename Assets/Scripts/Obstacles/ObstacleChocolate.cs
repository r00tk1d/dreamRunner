using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChocolate : MonoBehaviour
{
    private float speed = Obstacle.getSpeed();
    private Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = Obstacle.getSpeed();
        myRB.velocity = new Vector2(speed, 0);
    }

    //Destroy player if obstacle hits player
    void OnCollisionEnter2D(Collision2D col)
    {
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
