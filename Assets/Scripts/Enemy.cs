using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float stopDistance = 5f;
    private Transform playerTransform;
    private bool isAttacking = false;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= stopDistance && !isAttacking)
        {
            isAttacking = true;
            InvokeRepeating("FireProjectile", 0f, fireRate);
        }
    }

    private void FireProjectile()
    {
        Vector3 projectileDirection = (playerTransform.position - projectileSpawnPoint.position).normalized;
        Quaternion projectileRotation = Quaternion.LookRotation(projectileDirection);

        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileRotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        projectileRb.velocity = projectileDirection * projectileSpeed;
    }
}




