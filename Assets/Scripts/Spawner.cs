using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] items;
    public float spawnTime = DefValues.spawnTime;
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

            //decrease spawntime
            spawnTime = spawnTime - DefValues.decreaseSpawnTime;

            //increase overall obstaclespeed
            ObstacleSpeed.setSpeed(ObstacleSpeed.getSpeed() - DefValues.increaseSpeed);

            //obstacle or item
            if (Random.value > 0.9f)
            {
                //spawn Item
                int itemNumber = (int)Random.Range(0.0f, (float)items.Length);
                Debug.Log(itemNumber);
                SpawnItem(itemNumber);
            }
            else
            {
                //spawn Obstacle
                float random = Random.Range(0.0f, (float)obstacles.Length);

                switch ((int)random)
                {
                    case 0:
                        if (random > 0.6f)
                        {
                            SpawnChocolate();
                        }
                        else
                        {
                            SpawnRock();
                        }
                        break;
                    case 1:
                        SpawnRock();
                        break;
                    case 2:
                        SpawnBouncing();
                        break;
                    case 3:
                        //also SpawnBouncing because its on slot 4 of the obstacles (nneds a fix)
                        break;
                    default:
                        Debug.Log("Error: No Obstacle with id " + (int)random);
                        break;
                }
            }

        }
        yield return null;
    }

    void SpawnChocolate()
    {

        for (int j = -4; j < 5; j = j + 2)
        {
            spawnLocation.y = j;
            GameObject go = Instantiate(obstacles[1], spawnLocation, Quaternion.identity);
        }

    }

    void SpawnRock()
    {
        spawnLocation.y = Random.Range(-4.5f, 4.5f);
        GameObject go = Instantiate(obstacles[0], spawnLocation, Quaternion.identity);

    }

    void SpawnItem(int itemNumber)
    {
        spawnLocation.y = Random.Range(-4.5f, 4.5f);
        GameObject go = Instantiate(items[itemNumber], spawnLocation, Quaternion.identity);
    }

    void SpawnBouncing()
    {
        spawnLocation.y = -5f;
        GameObject jelly = Instantiate(obstacles[2], spawnLocation, Quaternion.identity); //TODO index sollte nicht hardgecodet sein
        spawnLocation.y = 4.7f;
        GameObject ball = Instantiate(obstacles[3], spawnLocation, Quaternion.identity); //TODO index sollte nicht hardgecodet sein

    }
}
