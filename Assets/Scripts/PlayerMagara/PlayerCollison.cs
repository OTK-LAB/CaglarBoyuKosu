using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollison : MonoBehaviour
{
    public static PlayerCollison instance;
    public PlayerController controller;
    public GameObject screen;
    public bool GameOver = false;
    public AudioSource Obstacle;
    public AudioSource Puan;

    private void Awake()
    {
        instance = this;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            PlayItemSound(Obstacle);
            GameOver = true;
            controller.enabled = false;
            screen.SetActive(true);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("puan"))
        {
            PlayItemSound(Puan);
            GameManager.instance.Score += 10;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }

    private void PlayItemSound(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}