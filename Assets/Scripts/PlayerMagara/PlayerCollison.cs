using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollison : MonoBehaviour
{
    public static PlayerCollison instance;
    public PlayerController controller;
    public GameObject screen;
    public bool GameOver = false;

    private void Awake()
    {
        instance = this;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            GameOver = true;
            controller.enabled = false;
            screen.SetActive(true);
        }

    }
}