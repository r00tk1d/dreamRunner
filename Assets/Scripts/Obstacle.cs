using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = -1f;
    private Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start(){
        myRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update(){
        myRB.velocity = new Vector2(speed, 0);
    }

    //Destroy player if obstacle hits player
    void OnCollisionEnter2D (Collision2D col){
        //Debug.Log("collision name = " + col.gameObject.name);
        if(col.gameObject.tag == "Player") {
            Destroy(col.gameObject);
        }
        
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
