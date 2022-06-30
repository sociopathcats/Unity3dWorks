using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange=9;
    public int enemycount;
    public int waveNumber=1;
    public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX=Random.Range(-spawnRange, spawnRange);
        float spawnPosZ=Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX,0,spawnPosZ);
        return spawnPos;
    }
    void SpawnEnemyWave(int enemySpawn)
    {
        for(int i=0; i < enemySpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemycount = FindObjectsOfType<EnemyController>().Length;
        if (enemycount == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            waveNumber++; SpawnEnemyWave(waveNumber);
        }
    }
}
