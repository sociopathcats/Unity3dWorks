using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    [SerializeField]private float horizonalSpeed=50f;
    public GameManager manager;
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        if (manager.isGameActive)
        {
            transform.Translate(Vector3.left*horizonalSpeed*Time.deltaTime);
        }
        
        
    }
}
