using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawn;
    private float RangeX=16;
    private float RangeZ=20;
    private float startDelay = 2;
    private float spawnInterval=1.5f;
    void SpawnRandomAnimal()
    {
        int animalindex = Random.Range(0, spawn.Length);
        Vector3 spawnposition = new Vector3(Random.Range(-RangeX, RangeX), 0, RangeZ);
        Instantiate(spawn[animalindex], spawnposition, spawn[animalindex].transform.rotation);
    }
    
    void Start()
    {
        
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
    }

    void Update()
    {
       
    }
}
