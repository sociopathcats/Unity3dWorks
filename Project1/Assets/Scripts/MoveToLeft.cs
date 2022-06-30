using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    [SerializeField]private float horizonalSpeed=50f;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.left*horizonalSpeed*Time.deltaTime);
    }
}
