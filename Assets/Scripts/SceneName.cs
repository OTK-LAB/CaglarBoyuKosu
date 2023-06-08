using UnityEngine;
using UnityEngine.UI;

public class SceneName : MonoBehaviour
{
    public Text sceneNameText;
    public float displayDuration = 5f;

    private void Start()
    {
        // Sahne adýný alýp metin nesnesine atama
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        sceneNameText.text = sceneName;

        // Belirli süre sonra metin nesnesini kapatma
        Invoke("HideSceneName", displayDuration);
    }

    private void HideSceneName()
    {
        // Metin nesnesini kapatma
        sceneNameText.gameObject.SetActive(false);
    }
}
