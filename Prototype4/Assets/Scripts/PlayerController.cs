using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float forceFloat;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    private bool hasPowerUp;
    public float powerUpForce;
    private int cooldown = 7;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardinput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward*forceFloat*forwardinput);
        powerupIndicator.transform.position = transform.position+new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
        }

    }
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(cooldown);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            //Debug.Log("Collided with" + collision.gameObject.name + "with power up set" + hasPowerUp);
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayfromplayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayfromplayer * powerUpForce, ForceMode.Impulse);
        }
    }
}

