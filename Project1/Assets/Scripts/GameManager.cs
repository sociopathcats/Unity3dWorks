using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float astroidWidth = 10f;
    private const float cameraOrthoSize = 50f;
    private const float gapY = 20f;
    private const float spawnPosition = 100f;
    private float startDelay = 2;
    private float repeatRate = 20;
    public GameObject astroidPrefab;
    public Planet planetScript;
    public bool isGameOver=false;
    public GameObject orbitCenter;
    public float leftlimit = 10f;
    public bool isOrbitCenterOn = false;
    

    public void Start()
    {
       
        InvokeRepeating("SpawnPlanets",startDelay,repeatRate);
   
    }
    public void FixedUpdate()
    {
      
    }
   
    void SpawnAstroid()
    {
        CreateAstroidBelt(Random.Range(10, 85), spawnPosition);
    }
    void SpawnPlanets()
    {
        CreatePlanet(110,0,10,spawnPosition); 
    }
    private void CreateAstroidBelt(float height,float xPosition)
    { //bottomBelt
     
        Transform astroidBeltBottom=Instantiate(astroidPrefab.transform);
        astroidBeltBottom.position = new Vector3(xPosition, -cameraOrthoSize);
        //top
        Transform astroidBeltTop=Instantiate(astroidPrefab.transform);
        astroidBeltTop.position = new Vector3(xPosition, cameraOrthoSize-height);

        SpriteRenderer astroidBeltRenderer=astroidBeltBottom.GetComponent<SpriteRenderer>(); 
        astroidBeltRenderer.size=new Vector2(astroidWidth,-(height+gapY)+cameraOrthoSize*2 );
        //top
        SpriteRenderer astroidBeltTopRenderer=astroidBeltTop.GetComponent<SpriteRenderer>();
        astroidBeltTopRenderer.size=new Vector2(astroidWidth,height);

        BoxCollider2D astroidBoxCollider=astroidBeltBottom.GetComponent<BoxCollider2D>();
        astroidBoxCollider.size=new Vector2(astroidWidth, -(height + gapY) + cameraOrthoSize * 2);
        astroidBoxCollider.offset = new Vector2(0f, -(height + gapY) + cameraOrthoSize * 2 * .5f);
        //top
        BoxCollider2D astroidBoxColliderTop=astroidBeltTop.GetComponent<BoxCollider2D>();
        astroidBoxColliderTop.size = new Vector2(astroidWidth, height);
        astroidBoxColliderTop.offset = new Vector2(0f, height * .5f);
    }
   private void CreatePlanet(float positionX,float positionY,float size,float spawnPoint)
    {
        if (isOrbitCenterOn == false)
        {
        orbitCenter = Instantiate(orbitCenter);
        orbitCenter.transform.position = new Vector2(spawnPoint, 0);
        planetScript = GameObject.Find("Planet").GetComponent<Planet>();
        planetScript.transform.position = new Vector2(positionX, positionY);
        planetScript.transform.localScale = new Vector2(size, size);
        OrbitCenter();
        }
        
    }
    private void GameOver()
    {
        isGameOver = true;
        Debug.Log("GameOver");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Planet") && collision.gameObject.CompareTag("Astroid"))
        {
            GameOver();
        }
    }
   private void OrbitCenter()
    {
        if(orbitCenter != null)
        {
            isOrbitCenterOn = true;
        }
    }
}
