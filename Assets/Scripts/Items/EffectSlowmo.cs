using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSlowmo : MonoBehaviour
{
    public float slowmoTimer = 3f;
    public void Use(){
        StartCoroutine(Effect());
    }

    
    IEnumerator Effect(){
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(slowmoTimer);
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }
    
}
