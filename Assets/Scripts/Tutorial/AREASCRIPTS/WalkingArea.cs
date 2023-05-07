using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkingArea : MonoBehaviour
{
    public static WalkingArea instance;
    public bool isWalkingArea;
    public Text expText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isWalkingArea = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            expText.gameObject.SetActive(true);
            isWalkingArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            expText.gameObject.SetActive(false);
            isWalkingArea = false;
        }
    }
}
