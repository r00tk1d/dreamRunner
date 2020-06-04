using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float spawnTime = 2.0f;
    private Vector3 spawnLocation = new Vector3(12.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
        //InvokeRepeating("InitObstacles",0.0f,spawnTime);
    }

    IEnumerator ExampleCoroutine()
    {
        // TODO solange der Spieler lebt
        while(true){
            yield return new WaitForSeconds(spawnTime);
            Instantiate(obstacles[0], spawnLocation, Quaternion.identity);
            
            //increase spawntime
            if(spawnTime > 0.6){
                spawnTime = spawnTime - 0.03f;
            }

            spawnLocation.y = Random.Range(-4.5f, 4.5f);
        }
    }
    
}
