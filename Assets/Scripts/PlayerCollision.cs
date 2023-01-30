using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController controller;
    public GameObject screen;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            controller.enabled = false;
            Debug.Log("Carpti");
            screen.SetActive(true);
        }
        
    }

}
