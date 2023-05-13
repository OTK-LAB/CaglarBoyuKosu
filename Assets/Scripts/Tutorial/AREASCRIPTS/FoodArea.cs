using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodArea : MonoBehaviour
{
    public static FoodArea instance;
    public bool isFoodArea;
    public Text expText;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (PlayerHealth.instance.PlayerDied == true || PlayerCollison.instance.GameOver == true)
        {
            expText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            expText.gameObject.SetActive(true);
            isFoodArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            expText.gameObject.SetActive(false);
            isFoodArea = false;
        }
    }
}
