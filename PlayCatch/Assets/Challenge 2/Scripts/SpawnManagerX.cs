using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -40;
    private float spawnLimitXRight = 0;
    private float spawnPosY = 40;
    private float startDelay = 1.0f;


    // Start is called before the first frame update
    void Start()
    {

        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        int ballindex = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[ballindex], spawnPos, ballPrefabs[ballindex].transform.rotation);
        Invoke("SpawnRandomBall", Random.Range(3, 5));
    }

}
