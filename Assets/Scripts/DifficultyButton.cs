using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public  int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        //在場景層次結構中尋找名稱(Game Manager)的遊戲物件，
        //並取得附加在該遊戲物件上的<GameManager>腳本的組件。
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        //AddListener:在特定事件發生時執行某些操作
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty(){
        Debug.Log(gameObject.name + "was clecked");
        gameManager.StartGame(difficulty);
    }
}
