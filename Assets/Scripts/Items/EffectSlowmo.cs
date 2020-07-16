using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectSlowmo : MonoBehaviour
{
    public float slowmoTimer = 3f;
    public float slotSlowdownTime = 4f;
    private AudioSource inGameMusic;

    void Start()
    {
        inGameMusic = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
    }
    public void Use()
    {
        StartCoroutine(Effect());
        StartCoroutine(ItemslotSlowdownTime());

    }

    IEnumerator Effect()
    {        
        Time.timeScale = 0.5f;
        inGameMusic.pitch = 0.5f;
        yield return new WaitForSeconds(slowmoTimer);
        Time.timeScale = 1.0f;
        inGameMusic.pitch = 1.0f;
    }

    IEnumerator ItemslotSlowdownTime()
    {
        gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(slotSlowdownTime);
        Destroy(gameObject);
    }

}
