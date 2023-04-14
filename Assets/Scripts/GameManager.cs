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
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public bool isPause;
    private float spawnRate = 1.0f;
    private int score;
    private int lives;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject pauseScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            PauseGame();
        }
    }

    IEnumerator SpawnTarget(){
        while (isGameActive){
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    //更新分數
    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
    //更新生命
    public void UpdateLives(int livesToAdd){
        lives += livesToAdd;
        livesText.text = "Lives:" + lives;
        if (lives == 0){
            GameOver();
            livesText.gameObject.SetActive(false);
        }
    }
    //開始遊戲
    public void StartGame(int difficulty){
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(3);

    }
    //暫停遊戲
    public void PauseGame(){
        if (!isPause){
            isPause = true;
            //Zawarudo!
            Time.timeScale = 0;
            GetComponent<AudioSource>().Pause();
            pauseScreen.SetActive(true);
        }
        else{
            isPause = false;
            Time.timeScale = 1;
            GetComponent<AudioSource>().Play();
            pauseScreen.SetActive(false);
        }
    }
    //結束遊戲
    public void GameOver(){
        isGameActive = false;
        //跳出gameover訊息
        gameOverText.gameObject.SetActive(true);
        //跳出restart按鈕
        restartButton.gameObject.SetActive(true);
    }
    //重新開始
    public void RestartGame(){
        //獲取當前活動場景名稱，並傳遞給LoadScene(重新加載)
        //用於重製場景或從頭開始
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
