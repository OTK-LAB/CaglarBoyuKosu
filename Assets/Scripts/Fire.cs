using UnityEngine;

public class Fire: MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float stopDistance = 5f;
    private Transform enemyTransform;
    private bool isAttacking = false;
    //private bool hasFired = false; // FireProjectile() fonksiyonunun çağrılıp çağrılmadığını kontrol etmek için bir bool değişkeni

    private Animator animator;

    void Start()
    {
        //animator = GetComponent<Animator>();
        //enemyTransform = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            InvokeRepeating("FireProjectile", 0f, fireRate);
        }
    }

    public void FireProjectile()
    {
        isAttacking = true;
        Vector3 projectileDirection = transform.forward;
        Quaternion projectileRotation = Quaternion.LookRotation(projectileDirection);

        GameObject projectile = Instantiate(bulletPrefab, bulletSpawnPoint.position, projectileRotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        projectileRb.velocity = projectileDirection * bulletSpeed;
    }


}


