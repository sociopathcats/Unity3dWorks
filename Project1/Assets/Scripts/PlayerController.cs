using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float upLimit;
    public float bottomLimit;
    public Rigidbody2D playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        Limit();
        TouchMove();
    }
    void TouchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.y > 0)
            {
                transform.Translate(Vector3.up * moveSpeed*Time.deltaTime);
                //transform.Translate(0, moveSpeed*Time.deltaTime, 0);
                //up
            }
            if (mousePos.y < 0)
            {
                transform.Translate(Vector3.down * moveSpeed*Time.deltaTime);
                //down
                //transform.Translate(0,-moveSpeed*Time.deltaTime,0);
            }
        }
    }
    void Limit()
    {
        if (transform.position.y > upLimit)
        {
            transform.position = new Vector3(transform.position.x, upLimit, transform.position.z);
            playerRb.AddForce(Vector3.down * moveSpeed);
        }
        if (transform.position.y < bottomLimit)
        {
            transform.position = new Vector3(transform.position.x, bottomLimit, transform.position.z);
            playerRb.AddForce(Vector3.up * moveSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Astroid"))
        {
            Debug.Log("GameOver");
        }
        
    }


}