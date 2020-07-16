using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSlowmo : MonoBehaviour
{
    public float slowmoTimer = 5f;
    public float slotSlowdownTime = 3f;
    private AudioSource inGameMusic;
    public void Use()
    {
        StartCoroutine(Effect());
        StartCoroutine(ItemslotSlowdownTime());
        
    }


    IEnumerator Effect()
    {
        inGameMusic = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
        Time.timeScale = 0.5f;
        inGameMusic.pitch = 0.5f;
        yield return new WaitForSecondsRealtime(slowmoTimer);
        Debug.Log(Time.deltaTime * slowmoTimer);
        if(Time.timeScale == 0.5f){
            Time.timeScale = 1.0f;
        }
        inGameMusic.pitch = 1.0f;
    }

    IEnumerator ItemslotSlowdownTime()
    {
        yield return new WaitForSecondsRealtime(slotSlowdownTime);
        Destroy(gameObject);
    }

}
