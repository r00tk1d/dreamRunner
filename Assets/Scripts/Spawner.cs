using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] items;
    public float spawnTime;
    private Vector3 spawnLocation = new Vector3(12.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = DefValues.spawnTime;
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnTime, spawnTime + 0.2f));

            //decrease spawntime until maxspawntime is reached
            if (spawnTime > DefValues.maxSpawnTime)
            {
                spawnTime = spawnTime - DefValues.decreaseSpawnTime;
            }

            //increase overall obstaclespeed if max Speed isnt reached
            if (DefValues.maxSpeed < ObstacleSpeed.getSpeed())
            {
                ObstacleSpeed.setSpeed(ObstacleSpeed.getSpeed() - DefValues.increaseSpeed);
            }

            //obstacle or item
            if (Random.value > 0.9f)
            {
                //spawn Item
                int itemNumber = (int)Random.Range(0.0f, (float)items.Length);
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
                        SpawnRock();
                        break;
                    default:
                        Debug.LogError("No Obstacle with id " + (int)random);
                        break;
                }
            }

        }
        yield return null;
    }

    void SpawnChocolate()
    {
        float spawn = Random.Range(-4.5f, 0);
        for (int j = 0; j < 3; j++)
        {
            spawnLocation.y = spawn;
            GameObject go = Instantiate(obstacles[1], spawnLocation, Quaternion.identity);
            spawn += 2f;
        }

    }

    void SpawnRock()
    {
        spawnLocation.y = Random.Range(-4.5f, 4.5f);
        GameObject go = Instantiate(obstacles[0], spawnLocation, Quaternion.identity);
        Renderer renderer = go.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
    }

    void SpawnBouncing()
    {
        spawnLocation.y = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).y + 0.7f;
        GameObject jelly = Instantiate(obstacles[2], spawnLocation, Quaternion.identity); //TODO index sollte nicht hardgecodet sein
        spawnLocation.y = 4.7f;
        GameObject ball = Instantiate(obstacles[3], spawnLocation, Quaternion.identity); //TODO index sollte nicht hardgecodet sein

    }

    void SpawnItem(int itemNumber)
    {
        //multipler Item erst nach score 50 spawnen
        if (!(itemNumber == 1 && (int)FindObjectOfType<Score>().score < 50))
        {
            spawnLocation.y = Random.Range(-4.5f, 4.5f);
            GameObject go = Instantiate(items[itemNumber], spawnLocation, Quaternion.identity);
        }

    }


}
