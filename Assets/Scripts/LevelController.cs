using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private FınıshLine finish;
    private EnemyHealth enemy;
    public GameObject screen;
    public PlayerController playerController;

    private void Start()
    {
        finish = FindObjectOfType<FınıshLine>();
        enemy = FindObjectOfType<EnemyHealth>();
        playerController = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        NextLevel();
    }

    private void NextLevel()
    {
        if (finish.isFinished && enemy.isEnemydie)
        {
            playerController.enabled = false;
            screen.SetActive(true);
        }
    }
}