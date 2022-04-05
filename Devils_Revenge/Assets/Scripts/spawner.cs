using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject objToSpawn;
    public Transform boundOne;
    public Transform boundTwo;
    public float maxSpawnTime;
    public float minSpawnTime;
    float spawnTime;
    public float spawnStepTime;
    public float spawnHeight;
    Vector3 desiredPos;

    int enemiesInScene;
    public int maxEnemies;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = maxSpawnTime;
        Invoke("spawnEnemy", spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesInScene = enemies.Length;
    }
    void spawnEnemy()
    {
        if (enemiesInScene < maxEnemies)
        {
            desiredPos = new Vector3(Random.Range(boundOne.position.x, boundTwo.position.x), spawnHeight, Random.Range(boundOne.position.z, boundTwo.position.z));

            GameObject spawnedEnemy = Instantiate(objToSpawn, desiredPos, Quaternion.identity);
        }
        if (spawnTime > minSpawnTime+spawnStepTime)
        {
            spawnTime -= spawnStepTime;
        }
        Invoke("spawnEnemy", spawnTime);
    }
}
