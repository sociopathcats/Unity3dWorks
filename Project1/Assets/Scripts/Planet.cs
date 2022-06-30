using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject pivotPoint;
    public float speed;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

     transform.RotateAround(pivotPoint.transform.position,Vector3.forward,speed*Time.deltaTime);
    }

}
