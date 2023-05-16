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
    public GameObject normalBulletPrefab;
    public GameObject fastBulletPrefab;
    public GameObject powerfulBulletPrefab;
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
    public AudioSource fire;

    public static BossController instance;

    public enum FireMode
    {
        Normal,
        Fast,
        Powerful
    }

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
                    FireMode selectedFireMode = SelectFireMode();
                    Attack = true;
                    FireProjectile(selectedFireMode);
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

     }

    IEnumerator ResetBoolAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Attack = false;
    }

    private FireMode SelectFireMode()
    {
        int randomValue = Random.Range(0, 3);
        return (FireMode)randomValue;
    }

    public void FireProjectile(FireMode fireMode)
    {
      
        switch (fireMode)
        {
            case FireMode.Normal:
                // Normal ateþ etme modu kodlarý
                fire.Play();
                Vector3 projectileDirectionNormal = (player.position - projectileSpawnPoint.position);
                projectileDirectionNormal.y += 2f; // y eksenine +1 ekleniyor
                projectileDirectionNormal = projectileDirectionNormal.normalized;

                Quaternion projectileRotationNormal = Quaternion.LookRotation(projectileDirectionNormal);

                GameObject projectileNormal = Instantiate(normalBulletPrefab, projectileSpawnPoint.position, projectileRotationNormal);

                Rigidbody projectileRbNormal = projectileNormal.GetComponent<Rigidbody>();
                projectileRbNormal.velocity = (projectileDirectionNormal * projectileSpeed) * 1.75f;

                // Normal ateþ etme moduna özgü ek kodlar...

                Destroy(projectileNormal, 4f);
                break;

            case FireMode.Fast:
                // Hýzlý ateþ etme modu kodlarý
                fire.Play();
                Vector3 projectileDirectionFast = (player.position - projectileSpawnPoint.position);
                projectileDirectionFast.y += 2f; // y eksenine +1.5 ekleniyor
                projectileDirectionFast = projectileDirectionFast.normalized;

                Quaternion projectileRotationFast = Quaternion.LookRotation(projectileDirectionFast);
                GameObject projectileFast = Instantiate(fastBulletPrefab, projectileSpawnPoint.position, projectileRotationFast);

                Rigidbody projectileRbFast = projectileFast.GetComponent<Rigidbody>();
                projectileRbFast.velocity = (projectileDirectionFast * projectileSpeed) * 2f;

                // Hýzlý ateþ etme moduna özgü ek kodlar...

                Destroy(projectileFast, 4f);
                break;

            case FireMode.Powerful:
                // Güçlü ateþ etme modu kodlarý
                fire.Play();
                Vector3 projectileDirectionPowerful = (player.position - projectileSpawnPoint.position);
                projectileDirectionPowerful.y += 2f; // y eksenine +1 ekleniyor
                projectileDirectionPowerful = projectileDirectionPowerful.normalized;

                Quaternion projectileRotationPowerful = Quaternion.LookRotation(projectileDirectionPowerful);
                GameObject projectilePowerful = Instantiate(powerfulBulletPrefab, projectileSpawnPoint.position, projectileRotationPowerful);

                Rigidbody projectileRbPowerful = projectilePowerful.GetComponent<Rigidbody>();
                projectileRbPowerful.velocity = (projectileDirectionPowerful * projectileSpeed) * 1.25f;

                // Güçlü ateþ etme moduna özgü ek kodlar...

                Destroy(projectilePowerful, 4f);
                break;
        }

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
