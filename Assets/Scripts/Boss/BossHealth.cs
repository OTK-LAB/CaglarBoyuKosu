using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int startingHealth = 200;
    public int currentHealth;
    public Slider healthBar;
    private GameManager gameManager;
    public bool isBossDied = false;
    public BossController bossController;
    public AudioSource hit;
    public AudioSource Died;

    // Start is called before the first frame update
    void Start()
    {
        bossController = GetComponent<BossController>();

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
            Debug.Log("Boss vuruldu");
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
        Died.Play();
        isBossDied = true;

    }
}
