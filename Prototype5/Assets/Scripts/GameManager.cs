using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> target;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;
    private float spawnRate = 1.0f;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    

    // Start is called before the first frame update
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        isGameActive=true;
        
        
        restartButton.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
         
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
      
    }
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
        yield return new WaitForSeconds(spawnRate);
        int index=Random.Range(0,target.Count);
        Instantiate(target[index]);
            scoreText.gameObject.SetActive(true);

        }
       
    }
    public  void UpdateScore(int scoreToAdd)
    {
        scoreText.text = "Score: " + score;
        score+=scoreToAdd;
    }
}
