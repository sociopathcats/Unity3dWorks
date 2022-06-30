using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;
    private float maxSpeed=16;
    private float minSpeed=12;
    private float torque=10;
    private float spawnPosX=4;
    private float spawnPosY=2;
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPosition();
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void Score()
    {
        gameManager.UpdateScore(pointValue);
    }
    private void OnMouseDown()
    {
        
        if (gameManager.isGameActive) { Score();
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);} 
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-torque, torque);
    }
    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-spawnPosX, spawnPosX), -spawnPosY);
    }
}
