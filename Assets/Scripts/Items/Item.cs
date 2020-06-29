using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
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
        myRB.velocity = new Vector2(speed, 0);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
