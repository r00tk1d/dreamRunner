using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlowmo : MonoBehaviour
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

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
