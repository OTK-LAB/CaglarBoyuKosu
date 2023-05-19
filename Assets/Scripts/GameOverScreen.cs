using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    private int scoreNum = 0;
    public GameObject screen;


    void Start()
    {
        pointsText.text = $"Your score is {scoreNum}.";
    }
    void Update()
    {
        Setup(GameManager.instance.Score);
    }
    public void Setup(int score)
    {
        scoreNum = score;
        pointsText.text = $"Your score is {scoreNum}.";
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
