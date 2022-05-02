using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public Text GameOverText;

    private void Awake(){
        if(instance == null)
            instance = this;
        else{
            Debug.LogError("More than one GameManager");
        }
    }   
    public void GameOver(){
        Debug.Log("Game Over");
        
        GameOverText.gameObject.SetActive(true);
        
        
        //暫停遊戲
        // while(!Input.GetKeyDown(KeyCode.R))
        //     Debug.Log(("wait for restart"));
        
        SceneManager.LoadScene(1);
        //跳回主選單

    }
    public void StartGame(){
        SceneManager.LoadScene(0);
    }
}
