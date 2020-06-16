using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
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
            spawnTime = spawnTime - DefValues.decreaseSpawnTime;
            Obstacle.setSpeed(Obstacle.getSpeed() - DefValues.increaseSpeed);
            float random = Random.Range(0.0f, (float)obstacles.Length);
            switch ((int)random)
            {
                case 0:
                    if (random > 0.6f)
                    {
                        SpawnChocolate();
                    }else{
                        SpawnRock();
                    }
                    break;
                case 1:
                    SpawnRock();
                    break;
                default:
                    Debug.Log("Error: No Obstacle with id " + (int)random);
                    break;
            }

        }
    }

    void SpawnChocolate()
    {
        //for (int i = 0; i < 3; i++)
        //{
        for (int j = -4; j < 5; j = j + 2)
        {
            spawnLocation.y = j;
            GameObject go = Instantiate(obstacles[1], spawnLocation, Quaternion.identity);
        }
        //spawnLocation.x = spawnLocation.x + 2;

        //}
    }

    void SpawnRock()
    {
        /**
        int numberRocks = (int)Random.Range(0.0f, 5.5f);
        for (int i = 0; i < numberRocks; i++)
        {
            
        }
        **/
        //yield return new WaitForSeconds(numberRocks);
        spawnLocation.y = Random.Range(-4.5f, 4.5f);
        GameObject go = Instantiate(obstacles[0], spawnLocation, Quaternion.identity);

    }
}
