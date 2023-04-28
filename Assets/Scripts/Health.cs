using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthBar;
    public Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        
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


    void OnTriggerEnter(Collider other)  // Debug.Log fonksiyonları çağırılmıyor bir hata var!!!
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // Stone objesiyle çarpıştığımızda canımız azalıyor
            TakeDamage(10);
            Debug.Log("Canavar vuruldu");
        }

        else if(other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            Debug.Log("Oyuncu vuruldu");
        }
    }

    void TakeDamage(int damage)
    {
        Debug.Log("Fonksiyon çalıştı");
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
        _renderer.enabled = false;
        // karakter ölürse burada ölüm işlemleri yapılabilir
        // örneğin oyunun yeniden başlatılması veya bölüm geçiş ekranının açılması gibi
    }
}

