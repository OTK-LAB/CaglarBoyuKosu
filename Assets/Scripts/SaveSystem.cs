using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour// SAHNEYİ SÜREKLİ YÜKLÜYOR BU YÜZDEN OYUN BAŞLAMIYOR
{
    public int startingLevel = 1; // Başlangıç seviyesi
    public int currentLevel; // Mevcut seviye

    private void Start()
    {
        // Mevcut seviyeyi kaydedilen seviye verisinden al
        currentLevel = PlayerPrefs.GetInt("SavedLevel", startingLevel);

        // Son kaldığın seviyeden devam etmek için LoadLevel fonksiyonunu çağır
        Debug.Log("sahne yüklendi");
        LoadLevel(currentLevel);
    }

    public void SaveLevel(int level)
    {
        // Seviye verisini kaydet ve currentLevel değişkenini güncelle
        PlayerPrefs.SetInt("SavedLevel", level);
        PlayerPrefs.Save();
        currentLevel = level;
    }

    public void LoadLevel(int level)
    {
        // Seviye yöneticisi veya oyun kontrolcüsü tarafından çağrıldığında, oyuncuyu ilgili seviyeye yerleştir
        // Burada seviye yükleme mantığı bulunmalı
        SceneManager.LoadScene(level);
    }

    public void LoadNextLevel()
    {
        // Mevcut seviyeyi kaydet ve currentLevel değişkenini güncelle
        SaveLevel(currentLevel + 1);

        // Bir sonraki seviyeye yönlendir
        LoadLevel(currentLevel+1);
    }

    public void ResetProgress()
    {
        // İlerlemeyi sıfırla ve başlangıç seviyesine yönlendir
        PlayerPrefs.DeleteKey("SavedLevel");
        currentLevel = startingLevel;
        LoadLevel(currentLevel);
        currentLevel = startingLevel;
    }

}
