using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalspeed;
    public float horizontalinput;
    public float RangeX;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");
        transform.Translate (Vector3.right*horizontalinput*horizontalspeed*Time.deltaTime);
        if (transform.position.x > RangeX)
        {
            transform.position=new Vector3(RangeX,transform.position.y,transform.position.z);
        }
        if(transform.position.x < -RangeX)
        {
            transform.position = new Vector3(-RangeX,transform.position.y,transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab,transform.position,projectilePrefab.transform.rotation);
        }
    }
}
