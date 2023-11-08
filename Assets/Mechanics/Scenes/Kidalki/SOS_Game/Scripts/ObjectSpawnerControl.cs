using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerControl : MonoBehaviour
{

    [Range(0, 5)]
    public float speedSpawn = 2f;

    public Transform[] spawnPoints;
    public GameObject[] objects;
    private int randomSpawnPoint, randomMonster;

    public static bool spawnAllowed;

    private void Start()
    {
        spawnAllowed = true;
        StartCoroutine(SpawnObjects());
        //InvokeRepeating("SpawnAMonster", 0f, speedSpawn);
    }

    public void SpawnAMonster()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, objects.Length);
            Instantiate(objects[randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }

    public IEnumerator SpawnObjects ()
    {
        while (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, objects.Length);
            Instantiate(objects[randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);

            yield return new WaitForSeconds(speedSpawn);
        }
    }

    //public void DieEnemies()
    //{
    //    for(int i = 0; i < objects.Length; i++)
    //    {
    //        Destroy(objects[i]);
    //    }
    //}

}
