using System;
using UnityEngine;

public class DestroyOutOfScene : MonoBehaviour
{
    private float leftLimit = -3.0f;
    private PlayerController playerControllerScript;
    private float rightLimit = 15.0f;
  
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
        if (playerControllerScript.gameOver == true&& rightLimit<transform.position.x)
        {  Destroy(gameObject); 
            
        }
    }



}
