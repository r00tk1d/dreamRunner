using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{
    public float speed;
    public AudioSource collectItemSound;
    private float deltaX, deltaY;
    private Joystick joystick;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        joystick = (Joystick)FindObjectOfType(typeof(Joystick));
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bonusShip"){
            Destroy(col.gameObject);
        }
    }

    public void collectItem(){
        collectItemSound.Play();
    }


    /**
        void Update(){
            if (Input.touchCount > 0){
                Touch touch = Input.GetTouch(0);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                switch(touch.phase){
                    case TouchPhase.Began:
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        break;
                    case TouchPhase.Moved:
                        rb2d.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                        break;
                    case TouchPhase.Ended:
                        rb2d.velocity = Vector2.zero;
                        break;
                }
            }
        }
    **/


}
