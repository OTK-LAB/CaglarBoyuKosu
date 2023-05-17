using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseScreen;
    //private bool isPaused = false;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (isPaused)
        //        ResumeGame();
        //    else
        //        ButtonPauseGame();
        //}
    }

    public void ButtonPauseGame()
    {
        Time.timeScale = 0f; // Oyun zamanýný duraklat
        //isPaused = true;
        pauseScreen.SetActive(true); // Pause ekranýný aktif hale getir
    }

    //public void ResumeGame()
    //{
    //    Time.timeScale = 1f; // Oyun zamanýný geri baþlat
    //    //isPaused = false;
    //    pauseScreen.SetActive(false); // Pause ekranýný devre dýþý býrak
    //}
}
