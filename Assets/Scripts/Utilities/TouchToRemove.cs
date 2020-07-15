using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToRemove : MonoBehaviour
{
    public AudioSource sound;
    void Update()
    {
        if (!PauseButton.isPaused && Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 camera = Camera.main.ScreenToWorldPoint(touch.position);

                    RaycastHit2D hit = Physics2D.Raycast(camera, Vector2.zero);
                    if (hit.collider != null && hit.collider.gameObject.name == "obstacleChocolate(Clone)")
                    {
                        Destroy(hit.collider.gameObject);
                        sound.Play();
                    }
                }
            }
        }
    }

}

