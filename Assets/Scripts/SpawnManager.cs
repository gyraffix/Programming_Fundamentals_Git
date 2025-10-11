using NUnit.Framework;
using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{

    private GameObject[] spawnPoints;

    public GameObject enemy;
    private bool canSpawn = true;
    public float spawnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            SpawnWave();
        }
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(spawnTime);
        canSpawn = true;
    }


    public void SpawnWave()
    {
        Instantiate(
            enemy,
            spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position,
            Quaternion.identity);
        canSpawn = false;
        StartCoroutine(SpawnTimer());

        
    }

}
