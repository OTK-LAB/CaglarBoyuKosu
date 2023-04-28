using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameOverScreen gameOverScreenPrefab;
    private GameOverScreen gameOverScreenInstance;
    private int maxPlatform = 0;
    private bool gameHasEnded = false;

    void Start()
    {

    }

    public void GameOver()
    {
        gameHasEnded = true;
        gameOverScreenInstance.Setup(maxPlatform);
    }
}
