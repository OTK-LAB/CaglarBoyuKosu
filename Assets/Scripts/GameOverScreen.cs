using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public int scoreNum;

    void start()
    {
        scoreNum = 0;
        pointsText.text = scoreNum + " POINTS";
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag =="puan"){
           scoreNum += 10;
           pointsText.text = scoreNum + " POINTS";
        }

    }

    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    public void RestartButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuButton(){
        SceneManager.LoadScene("Menu");
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }    
}

