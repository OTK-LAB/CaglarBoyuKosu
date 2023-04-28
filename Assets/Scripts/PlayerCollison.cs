using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollison : MonoBehaviour
{
    public PlayerController controller;
    public GameObject screen;
    private bool hasFinished = false;
    private bool isFinishedTriggered = false;
    private Enemy enemy;
    
    private void Awake()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            controller.enabled = false;
            screen.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Finish") && !isFinishedTriggered)
        {
            isFinishedTriggered = true;
            if (enemy != null)
            {
                InvokeRepeating("CallFireProjectile", 0f, 1f);
            }
        }
    }

    private void CallFireProjectile()
    {
        enemy.FireProjectile();
    }
}
