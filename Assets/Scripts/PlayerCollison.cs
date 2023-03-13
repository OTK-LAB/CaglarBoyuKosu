using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollison : MonoBehaviour
{
    public PlayerController controller;
    public GameObject screen;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "rock")
        {
            controller.enabled = false;
            Debug.Log("Carpti");
            screen.SetActive(true);
        }

    }
}
