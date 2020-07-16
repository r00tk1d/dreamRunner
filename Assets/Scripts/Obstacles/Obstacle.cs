using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float speed = ObstacleSpeed.getSpeed();
    private Rigidbody2D myRB;
    public AudioSource crashSound;
    spaceship ship;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        ship = GameObject.FindWithTag("Player").GetComponent<spaceship>();
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
        if (col.gameObject.tag == "Player")
        {
            crashSound.Play();
            FindObjectOfType<GameManager>().EndGame();
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "bonusShip"){
            Destroy(col.gameObject);
            ship.destroyBonusshipPlay();
        }

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void setGravityScale(float newGravScale){
        myRB.gravityScale = newGravScale;
    }

}
