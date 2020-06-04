using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float spawnTime = 2.0f;
    //public List<GameObject> obstaclesToSpawn = new List<GameObject>();
    //private int index;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InitObstacles",0.0f,spawnTime);
    }

    void InitObstacles(){
        Instantiate(obstacles[0], transform.position, Quaternion.identity);
                



        //obstaclesToSpawn.Add(obj);

/**
        for(int i = 0; i > obstacles.Length; i++) {
            GameObject obj = Instantiate(obstacles[index], transform.position, Quaternion.identity);
            obstaclesToSpawn.Add(obj);
            //obstaclesToSpawn[i].SetActive(false);
            index++;

            if(index == obstacles.Length){
                index = 0;
            }
        }
        **/

    }

/**
    IEnumerator SpawnRandomObstacles() {
        yield return new WaitForSeconds(Random.Range(1.5f, 4.5f));
        int index = Random.Range(0,obstaclesToSpawn.Count);

        while(true){
            if(!obstaclesToSpawn[index].activeInHierarchy) {
                obstaclesToSpawn[index].SetActive(true);
                break;
            }
        }
    }
    **/
}
