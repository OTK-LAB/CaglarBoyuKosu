using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpingArea : MonoBehaviour
{
    public static JumpingArea instance;
    public bool isJumpingArea;
    public Text expText;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            expText.gameObject.SetActive(true);
            isJumpingArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            expText.gameObject.SetActive(false);
            isJumpingArea = false;
        }
    }
}
