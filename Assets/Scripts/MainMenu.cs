using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

   }

    public void Continue()
    {
        int lastLevelIndex = PlayerPrefs.GetInt("LastLevelIndex", 1); // Kaydedilen son b�l�m�n index de�erini al�r (varsay�lan olarak 1)
        SceneManager.LoadScene(lastLevelIndex);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }    

}
