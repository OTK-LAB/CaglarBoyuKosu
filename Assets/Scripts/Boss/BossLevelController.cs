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
    public GameObject screen1;
    public GameObject screen2;
    public PlayerController playerController;
    public int lastLevelIndex;

    private void Start()
    {
        finish = FindObjectOfType<FınıshLine>();
        boss = FindObjectOfType<BossController>();
        playerController = FindObjectOfType<PlayerController>();
        lastLevelIndex = PlayerPrefs.GetInt("LastLevelIndex", 0); // En son bölüm indexini al
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
            screen1.SetActive(false);
            screen2.SetActive(false);

            int lastLevelIndex = PlayerPrefs.GetInt("LastLevelIndex", 1);
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

            // Eğer şu anki bölümün indexi en son kaydedilen bölümün indexinden büyükse,
            // en son bölüm indexini güncelle
            if ((currentLevelIndex + 1) > lastLevelIndex)
            {
                PlayerPrefs.SetInt("LastLevelIndex", (currentLevelIndex + 1));
                PlayerPrefs.Save();
            }
        }
    }
}