using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float waitTime = 2;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && waitTime >= 2)
        {
            SpawnDog();
            waitTime = 0;
        }
        waitTime += Time.deltaTime;
    }
    void SpawnDog()
    {
        Instantiate (dogPrefab, transform.position, dogPrefab.transform.rotation);  
    }
}
