using UnityEngine;

public class SpawnManager : MonoBehaviour

{
    public GameObject[] spawnedObjects;
    public Vector3 spawnPosition = new Vector3(16, 0, 0);
    private float spawnTime = 2.0f;
    private float startTime = 1.0f;
    private PlayerController playerControllerScript;
    

    void SpawnObjects()
    {
        int spawnedObjectsIndex = Random.Range(0, spawnedObjects.Length);
        Instantiate(spawnedObjects[spawnedObjectsIndex], spawnPosition, spawnedObjects[spawnedObjectsIndex].transform.rotation);
        if (playerControllerScript.gameOver == false)
        {
            Invoke("SpawnObjects", Random.Range(spawnTime, 4));
        }
    
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnObjects", startTime);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
