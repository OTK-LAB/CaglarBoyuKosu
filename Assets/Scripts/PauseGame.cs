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
        Time.timeScale = 0f; // Oyun zaman�n� duraklat
        //isPaused = true;
        pauseScreen.SetActive(true); // Pause ekran�n� aktif hale getir
    }

    //public void ResumeGame()
    //{
    //    Time.timeScale = 1f; // Oyun zaman�n� geri ba�lat
    //    //isPaused = false;
    //    pauseScreen.SetActive(false); // Pause ekran�n� devre d��� b�rak
    //}
}
