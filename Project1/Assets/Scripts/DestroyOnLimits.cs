using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLimits : MonoBehaviour
{
    public GameManager gameManager;
    private float leftLimit=-220f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
   
    void Update()
    {
        if (transform.position.x < leftLimit)
        {
            DestroyObject(gameObject);
            gameManager.isOrbitCenterOn = false;
        }
        
    }
}
