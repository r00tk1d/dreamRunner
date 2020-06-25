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

    //Destroy player if obstacle hits player
    IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Item collected");
            Destroy(gameObject);
            Time.timeScale = 0.5f;
            yield return new WaitForSeconds(1f);
            Debug.Log("on it goes");
            Time.timeScale = 1.0f;
        }

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
