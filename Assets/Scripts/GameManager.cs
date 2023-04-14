using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    private float spawnRate = 1.0f;
    private int score;
    public Button restartButton;
    public GameObject titleScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget(){
        while (isGameActive){
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    //讓其他程式取用
    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    public void StartGame(int difficulty){
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    public void GameOver(){
        isGameActive = false;
        //跳出gameover訊息
        gameOverText.gameObject.SetActive(true);
        //跳出restart按鈕
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame(){
        //獲取當前活動場景名稱，並傳遞給LoadScene(重新加載)
        //用於重製場景或從頭開始
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
