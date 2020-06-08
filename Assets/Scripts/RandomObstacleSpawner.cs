using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float spawnTime = 2.0f;
    public float speed = -1.0f;
    private Vector3 spawnLocation = new Vector3(12.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        while(true){
            yield return new WaitForSeconds(spawnTime);
            int random = (int)Random.Range(0.0f, (float)obstacles.Length);
            GameObject go = Instantiate(obstacles[random], spawnLocation, Quaternion.identity);

            // increase Obstacle speed
            speed = speed - 0.1f;
            go.SendMessage("setSpeed", speed);
            
            // decrease slowly spawntime, then random
            if(spawnTime > 0.5){
                spawnTime = spawnTime - 0.03f;
            }
            else {
                spawnTime = Random.Range(0.3f, 0.6f);
            }

            // random spawnlocation
            spawnLocation.y = Random.Range(-4.5f, 4.5f);
        }
    }
    
}
