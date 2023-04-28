using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private float stopDistance;
    private float lastFireTime = 0f;
    private Transform enemyTransform;
    private bool isAttacking = false;

    private Animator animator;

    void Start()
    {
        //animator = GetComponent<Animator>();
        enemyTransform = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void Update()
    {
        float distanceToEnemy = Vector3.Distance(transform.position, enemyTransform.position);

        if (distanceToEnemy <= stopDistance && Input.GetMouseButton(0))
        {
            FireProjectile();
        }
    }

    public void FireProjectile()
    {
        float currentTime = Time.time;

        // Saniyede bir kez ateş etme kontrolü
        if (currentTime - lastFireTime < fireRate)
        {
            return;
        }

        lastFireTime = currentTime;

        isAttacking = true;

        Vector3 projectileDirection = transform.forward;
        Quaternion projectileRotation = Quaternion.LookRotation(projectileDirection);

        GameObject projectile = Instantiate(bulletPrefab, bulletSpawnPoint.position, projectileRotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        projectileRb.velocity = projectileDirection * bulletSpeed;

        // Nesneyi 3 saniye sonra yok et
        Destroy(projectile, 3f);
    }

}
