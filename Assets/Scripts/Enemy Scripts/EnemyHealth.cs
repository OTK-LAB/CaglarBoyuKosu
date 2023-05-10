using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthBar;
    private GameManager gameManager;
    public bool isEnemydie = false;
    public Enemy EnemyScript;
    public AudioSource hit;
    // Start is called before the first frame update
    void Start()
    {
        EnemyScript = GetComponent<Enemy>();

        currentHealth = startingHealth;
        healthBar.maxValue = startingHealth;
        healthBar.value = startingHealth;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kursun"))
        {
            hit.Play();
            TakeDamage(10);
            Debug.Log("düþman vuruldu");
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
        isEnemydie = true;

    }
}
