using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectTripleShip : MonoBehaviour
{
    public float slotSlowdownTime = 1f;

    public GameObject spaceship;
    private Vector3 spawnLocation = new Vector3(-4.0f, 0.0f, 0.0f);
    public void Use()
    {
        Vector3 shipLocation = GameObject.FindGameObjectWithTag("Player").transform.position;

        GameObject[] bonusShips = GameObject.FindGameObjectsWithTag("bonusShip");

        if(bonusShips.Length > 0)
        {
            for (var i = 0; i < bonusShips.Length; i++)
            {
                Destroy(bonusShips[i]);
            }
        }



        Vector3 spawnLocation1 = new Vector3(shipLocation.x, shipLocation.y - 2f, shipLocation.z);
        GameObject ship1 = Instantiate(spaceship, spawnLocation1, Quaternion.identity);
        Vector3 spawnLocation2 = new Vector3(shipLocation.x, shipLocation.y + 2f, shipLocation.z);
        GameObject ship2 = Instantiate(spaceship, spawnLocation2, Quaternion.identity);

        StartCoroutine(ItemslotSlowdownTime());
    }


    IEnumerator ItemslotSlowdownTime()
    {
        gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSecondsRealtime(slotSlowdownTime);
        Destroy(gameObject);
    }

}
