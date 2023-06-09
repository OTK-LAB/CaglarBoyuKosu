using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthBar;
    private GameManager gameManager;
    public GameObject screen;
    public bool PlayerDied=false;
    [SerializeField] AudioSource GetHitSound;
    public AudioSource Died;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        currentHealth = startingHealth;
        healthBar.maxValue = startingHealth;
        healthBar.value = startingHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, startingHealth);
        healthBar.value = currentHealth;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NormalBullet"))
        {
            other.gameObject.SetActive(false);
            GetHitSound.Play();
            TakeDamage(10);
            Debug.Log("Oyuncu vuruldu");
        }

        if (other.gameObject.CompareTag("FastBullet"))
        {
            other.gameObject.SetActive(false);
            GetHitSound.Play();
            TakeDamage(5);
            Debug.Log("Oyuncu vuruldu");
        }

        if (other.gameObject.CompareTag("PowerfulBullet"))
        {
            other.gameObject.SetActive(false);
            GetHitSound.Play();
            TakeDamage(20);
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
        Died.Play();
        PlayerDied = true;
        //BossController.instance.Attack = false;
        gameObject.SetActive(false);
        screen.SetActive(true);
        if (gameManager != null)
        {
            gameManager.GameOver();
        }
        
    }
}
