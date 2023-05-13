using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthBar;
    public Renderer _renderer;

    private GameManager gameManager;
    private Rigidbody playerRigidbody;

    void Start()
    {
        _renderer = GetComponent<Renderer>();

        GameObject playerObject = GameObject.Find("Player"); // "Player" isimli nesneyi bulur
        playerRigidbody = playerObject.GetComponent<Rigidbody>(); // Player nesnesindeki Rigidbody bileşenine erişir

        gameManager = FindObjectOfType<GameManager>();

        
        currentHealth = startingHealth;
        healthBar.maxValue = startingHealth;
        healthBar.value = startingHealth;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kursun"))
        {
            TakeDamage(10);
            Debug.Log("Canavar vuruldu");
        }

        else if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            Debug.Log("Oyuncu vuruldu");
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        playerRigidbody.gameObject.SetActive(false);
        _renderer.enabled = false;

        if (gameManager != null)
        {
            gameManager.GameOver();
        }
    }

}
