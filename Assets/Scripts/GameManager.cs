using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int maxPlatform = 0;
    //private bool gameHasEnded = false;
    public static GameManager instance;
    public int newMax;
    public int Score = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        SetMaxPlatform(newMax);
    }

    public void GameOver()
    {
        //gameHasEnded = true;
    }

    public void SetMaxPlatform(int a)
    {
        maxPlatform = a;
    }

}

