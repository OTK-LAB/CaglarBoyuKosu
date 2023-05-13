using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossLevelController : MonoBehaviour
{
    private FınıshLine finish;
    private BossController boss;
    public GameObject screen;
    public PlayerController playerController;

    private void Start()
    {
        finish = FindObjectOfType<FınıshLine>();
        boss = FindObjectOfType<BossController>();
        playerController = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        NextLevel();
    }

    private void NextLevel()
    {
        if (finish.isFinished && boss.isBossDied)
        {
            playerController.enabled = false;
            screen.SetActive(true);
        }
    }
}