using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private float stopDistance;
    private Transform playerTransform;
    private bool isAttacking = false;
    private Animator animator;
    private EnemyHealth healthScript;
    private bool die = false;

    void Start()
    {
        healthScript = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        die = healthScript.isEnemydie;
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= stopDistance && !isAttacking)
        {
            
            isAttacking = true;           
            InvokeRepeating(nameof(FireProjectile), 0f, fireRate);
        }

        if (isAttacking == true)
        {
            animator.SetBool("IsThrowing", true);
        }
        else
        {
            animator.SetBool("IsThrowing", false);
        }

        StopShot();


    }
    public void FireProjectile()
    {
        isAttacking = true;
        Vector3 projectileDirection = (playerTransform.position - projectileSpawnPoint.position);
        projectileDirection.y = 0f; // y ekseni bileþenini sýfýrla
        projectileDirection = projectileDirection.normalized; // yeniden normalize et
        Quaternion projectileRotation = Quaternion.LookRotation(projectileDirection);

        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileRotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        projectileRb.velocity = (projectileDirection * projectileSpeed) * 1.5f;

        // Nesneyi 3 saniye sonra yok et
        Destroy(projectile, 3f);
    }

    private void StopShot()
    {
        if(die==true)
        {
            gameObject.SetActive(false);
            CancelInvoke(nameof(FireProjectile));
        }

        if(PlayerHealth.instance.PlayerDied == true)
        {
            isAttacking = false;
            CancelInvoke(nameof(FireProjectile));
            animator.SetBool("IsThrowing", false);
        }
    }

}
