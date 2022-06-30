using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRb;
    
    public float speed;
    private Vector3 lookdirection;
    private float bottomLimit=-2;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        lookdirection=(player.transform.position-transform.position).normalized;
        enemyRb.AddForce(lookdirection * speed);
        if (gameObject.transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
        
    }
}
