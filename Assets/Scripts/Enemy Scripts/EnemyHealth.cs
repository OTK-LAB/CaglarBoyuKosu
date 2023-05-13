using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthBar;
    private GameManager gameManager;
    public bool isEnemydie = false;
    public Enemy EnemyScript;
    public AudioSource hit;
    public SaveSystem ss;

    public string Level1 { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        EnemyScript = GetComponent<Enemy>();
        ss = GetComponent<SaveSystem>();
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
            Debug.Log("d��man vuruldu");
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
        ss.SaveLevel(ss.currentLevel);
    }
}
