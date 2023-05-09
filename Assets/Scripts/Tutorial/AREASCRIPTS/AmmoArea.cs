using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoArea : MonoBehaviour
{
    public static AmmoArea instance;
    public bool isAmmoArea;
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
            isAmmoArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            expText.gameObject.SetActive(false);
            isAmmoArea = false;
        }
    }
}
