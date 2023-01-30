using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    int maxPlatform = 0;
    bool gameHasEnded = false;
    

    public void GameOver()
    {
        GameOverScreen.Setup(maxPlatform);
    }
}
