using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const float astroidWidth = 2.68f;
    private const float cameraOrthoSize = 50f;
    private const float gapY = 20f;
    private const float spawnPosition = 100f;
    private float startDelay = 2;
    private float repeatRate = 1.5f;
    public GameObject astroidPrefab;
    public bool isGameActive;
    public GameObject gameOverText;
    public Button restartButton;
    private float score;
    private float perIncreasedScore;
    public TextMeshProUGUI scoreText;
    public float leftLimit = -190;
    public GameObject title;
    public GameObject ingame;
    public TextMeshProUGUI scoreEndGame;
    public TextMeshProUGUI highScore;
    public void Start()
    {
        score = 0f;
        perIncreasedScore = 100f;
        title.gameObject.SetActive(true);
        highScore.text="High Score\n"+PlayerPrefs.GetInt("HighScore",0).ToString();
    }
    public void StartGame()
    {
       
         InvokeRepeating("SpawnAstroid",startDelay,repeatRate);
        isGameActive = true; 
        ingame.gameObject.SetActive(true);
        title.gameObject.SetActive(false);
        
    }


    void SpawnAstroid()
    {
        if (isGameActive)
        {
            CreateAstroidBelt(Random.Range(10,60), spawnPosition);
        }
        
    }

    private void CreateAstroidBelt(float height, float xPosition)
    { //bottomBelt
        //6 is scale
        float bottomheight = (2 * cameraOrthoSize) - height - gapY;
        float beltSize = 6;
        Transform astroidBeltBottom = Instantiate(astroidPrefab.transform);
        astroidBeltBottom.position = new Vector3(xPosition, cameraOrthoSize-height-gapY);
        SpriteRenderer astroidBeltBottomRenderer=astroidBeltBottom.GetComponent<SpriteRenderer>(); 
        astroidBeltBottomRenderer.flipY = true;
         astroidBeltBottomRenderer.size=new Vector2(astroidWidth,(bottomheight)/beltSize);
        BoxCollider2D astroidBeltBottomBC=astroidBeltBottom.GetComponent<BoxCollider2D>();
        astroidBeltBottomBC.size = new Vector2(astroidWidth, (bottomheight / beltSize));
        astroidBeltBottomBC.offset = new Vector2(0, -(bottomheight/6/ 2));
        //top
        Transform astroidBeltTop = Instantiate(astroidPrefab.transform);
        astroidBeltTop.position = new Vector3(xPosition, cameraOrthoSize - height);
        SpriteRenderer astroidBeltTopRenderer =astroidBeltTop.GetComponent<SpriteRenderer>();
        astroidBeltTopRenderer.size=new Vector2(astroidWidth, (height/beltSize));
        BoxCollider2D astroidBeltTopBC=astroidBeltTop.GetComponent<BoxCollider2D>();
        astroidBeltTopBC.size=new Vector2(astroidWidth,(height/beltSize));
        astroidBeltTopBC.offset=new Vector2(0,(height/beltSize/2));
  
    }

    public void GameOver()
    {
        isGameActive = false;
        Debug.Log("Game Over!");
        gameOverText.SetActive(true);
        restartButton.gameObject.SetActive(true);
        scoreEndGame.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        scoreEndGame.text = "Score\n" + Mathf.RoundToInt(score);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartGame();
    }
    private void Update()
    {
        if (isGameActive)
        {

            score += perIncreasedScore*Time.deltaTime;
            UpdateScore();
          
        }
        
    }
    void UpdateScore()
    {
            scoreText.text = "Score: " + Mathf.RoundToInt(score);
            scoreEndGame.text = "Score: " + Mathf.RoundToInt(score);
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", Mathf.RoundToInt(score));
                highScore.text = "High Score" + Mathf.RoundToInt(score);
            }
    }





}

