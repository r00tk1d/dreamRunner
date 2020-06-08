using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float spawnTime = 20.0f;
    public float speed = -3.0f;
    private Vector3 spawnLocation = new Vector3(12.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            int random = (int)Random.Range(0.0f, (float)obstacles.Length);
            switch (random)
            {
                case 0:
                    SpawnChocolate();
                    break;
                case 1:
                    SpawnRock();
                    break;
                default:
                    Debug.Log("Error: No Obstacle with id " + random);
                    break;
            }


            // increase Obstacle speed
            //speed = speed - 0.1f;


            // decrease slowly spawntime, then random
            /*
            if (spawnTime > 0.5)
            {
                spawnTime = spawnTime - 0.03f;
            }
            else
            {
                spawnTime = Random.Range(0.3f, 0.6f);
            }
            */

            // random spawnlocation

        }
    }

    void SpawnChocolate()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = -4; j < 5; j = j + 2)
            {
                Debug.Log(i);
                spawnLocation.y = j;
                GameObject go = Instantiate(obstacles[1], spawnLocation, Quaternion.identity);
                go.SendMessage("setSpeed", speed);
            }
            spawnLocation.x = spawnLocation.x + 2;

        }
    }

    void SpawnRock()
    {
        spawnLocation.y = Random.Range(-4.5f, 4.5f);
        GameObject go = Instantiate(obstacles[0], spawnLocation, Quaternion.identity);
        go.SendMessage("setSpeed", speed);
    }
}
