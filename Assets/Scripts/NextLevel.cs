using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class NextLevel : MonoBehaviour
{
    public Text pointsText;
    public int scoreNum = 0;
    public GameObject screen;
    public static NextLevel instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pointsText.text = $"Your score is {scoreNum}.";
    }
    void Update()
    {
        Setup(scoreNum);
    }

    public void Setup(int score)
    {
        pointsText.text = $"Your score is {score}.";
        gameObject.SetActive(true);
    }

    public void NextLevelButton()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more levels in build settings!");
        }
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
