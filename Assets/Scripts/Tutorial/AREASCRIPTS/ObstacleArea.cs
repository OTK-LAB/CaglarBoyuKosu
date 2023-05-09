using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleArea : MonoBehaviour
{
    public static ObstacleArea instance;
    public bool isObstacleArea;
    public Text expText;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(PlayerHealth.instance.PlayerDied == true || PlayerCollison.instance.GameOver == true)
        {
            expText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            expText.gameObject.SetActive(true);
            isObstacleArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            expText.gameObject.SetActive(false);
            isObstacleArea = false;
        }
    }
}
