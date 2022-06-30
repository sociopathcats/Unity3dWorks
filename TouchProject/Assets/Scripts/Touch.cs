using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public float moveSpeed;
    public float upLimit;
    public float bottomLimit;
    public Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
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
                playerRb.AddForce(Vector3.up * moveSpeed);
                //transform.Translate(0, moveSpeed*Time.deltaTime, 0);
                //up
            }
            if (mousePos.y < 0)
            {
                playerRb.AddForce(Vector3.down * moveSpeed);
                //down
                //transform.Translate(0,-moveSpeed*Time.deltaTime,0);
            }
        }
    }
    void Limit()
    {
        if (transform.position.y > upLimit)
        {
            transform.position=new Vector3(transform.position.x, upLimit, transform.position.z);
        }
        if(transform.position.y < bottomLimit)
        {
            transform.position=new Vector3(transform.position.x,bottomLimit,transform.position.z);
        }
    }
    
    
}
