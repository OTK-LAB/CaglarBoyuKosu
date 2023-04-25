using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthBar;

    void Start()
    {
        
        
        if (healthBar == null)
        {
            Debug.LogError("healthBar is not assigned! Please assign a Slider object to the healthBar variable.");
        }
        else
        {   
            currentHealth = startingHealth;
            healthBar.maxValue = startingHealth;
            healthBar.value = startingHealth;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stone"))
        {
            // Stone objesiyle çarpıştığımızda canımız azalıyor
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        GetComponent<PlayerController>().enabled = false;
        // karakter ölürse burada ölüm işlemleri yapılabilir
        // örneğin oyunun yeniden başlatılması veya bölüm geçiş ekranının açılması gibi
    }
}

