using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSlowmo : MonoBehaviour
{
    public float slowmoTimer = 3f;
    public float slotSlowdownTime = 3f;
    public void Use()
    {
        StartCoroutine(Effect());
        StartCoroutine(ItemslotSlowdownTime());
    }


    IEnumerator Effect()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(slowmoTimer);
        Time.timeScale = 1.0f;
    }

    IEnumerator ItemslotSlowdownTime()
    {
        yield return new WaitForSecondsRealtime(slotSlowdownTime);
        Destroy(gameObject);
    }

}
