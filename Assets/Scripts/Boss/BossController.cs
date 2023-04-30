using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 4f;
    public float leftBoundary = -7.5f; // hareketin baþlayacaðý sol sýnýr
    public float rightBoundary = 7.5f; // hareketin baþlayacaðý sað sýnýr
    private float targetX; // hedef x pozisyonu
    public float attackDistance = 65f;
    public float lowHealthThreshold = 50f;
    public GameObject bulletPrefab;
    public float projectileSpeed = 100f;
    public Transform projectileSpawnPoint;
    public float projectileFireRate = 1f;
    public Slider healthBar;
    public bool Attack;
    private Transform player;
    private Rigidbody bossRigidbody;
    private float timeSinceLastAttack = 0f;
    private float currentHealth;
    private float startingHealth = 200f;
    public bool isBossDied = false;
    private float Hiz = 1f;

    public static BossController instance;

    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        // baþlangýçta objenin rastgele bir x pozisyonuna yerleþtirilmesi
        transform.position = new Vector3(Random.Range(leftBoundary, rightBoundary), transform.position.y, transform.position.z);
        currentHealth = startingHealth;
        healthBar.maxValue = startingHealth;
        healthBar.value = startingHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isBossDied)
        {
            return;
        }

        if (currentHealth > 0)
        {
            // objenin hareketi
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetX, moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);

            // hedef x pozisyonuna ulaþýldýðýnda yeni bir hedef belirleme
            if (Mathf.Approximately(transform.position.x, targetX))
            {
                targetX = Random.Range(leftBoundary, rightBoundary);
            }

            timeSinceLastAttack += Time.deltaTime;
            if (Vector3.Distance(transform.position, player.position) <= attackDistance && !PlayerHealth.instance.PlayerDied)
            {
                if(projectileFireRate <= timeSinceLastAttack)
                {
                    Attack = true;
                    FireProjectile();
                    timeSinceLastAttack = 0f;
                }
                
            }
        }

        if (Attack)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        if (currentHealth <= lowHealthThreshold)
        {
            Change();
        }
     }

    IEnumerator ResetBoolAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Attack = false;
    }

    public void FireProjectile()
    {
        Vector3 projectileDirection = (player.position - projectileSpawnPoint.position);
        projectileDirection.y += 1f; // y eksenine +1 ekleniyor
        projectileDirection = projectileDirection.normalized;

        Quaternion projectileRotation = Quaternion.LookRotation(projectileDirection);

        GameObject projectile = Instantiate(bulletPrefab, projectileSpawnPoint.position, projectileRotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.velocity = (projectileDirection * projectileSpeed) * Hiz;
        timeSinceLastAttack = 0f;
        Destroy(projectile, 4f);
    }

    private void Change()
    {
        projectileFireRate = 0.5f;
        Hiz = 1.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kursun"))
        {
            TakeDamage(10);
            Debug.Log("Boss vuruldu");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isBossDied = true;
        Destroy(gameObject);
    }
}
