using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGravity : MonoBehaviour
{
    public float slotSlowdownTime = 3f;
    public void Use()
    {
        Effect();
        StartCoroutine(ItemslotSlowdownTime());
    }


    private void Effect()
    {
        GameObject[] activeObstacles = GameObject.FindGameObjectsWithTag("obstacle");
        for (var i = 0; i < activeObstacles.Length; i++)
        {
            Rigidbody2D obj = activeObstacles[i].GetComponent<Rigidbody2D>();
            obj.constraints = RigidbodyConstraints2D.None;
            obj.gravityScale = 12;
        }
    }

    IEnumerator ItemslotSlowdownTime()
    {
        yield return new WaitForSecondsRealtime(slotSlowdownTime);
        Destroy(gameObject);
    }
}
