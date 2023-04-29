using UnityEngine;
using UnityEngine.EventSystems;

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
    public static Fire instance;

    private Animator animator;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //animator = GetComponent<Animator>();
        enemyTransform = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void Update()
    {
        float distanceToEnemy = Vector3.Distance(transform.position, enemyTransform.position);

        if (distanceToEnemy <= stopDistance && Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
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

            // Envantterdeki mermi sayısını kontrol et
            int ammoCount = PlayerInventory.instance.GetItemCount("ammo");
            if (ammoCount <= 0)
            {
                Debug.Log("Mermin Bitti");
                return;
            }

            // Mermi sayısını bir azalt
            PlayerInventory.instance.RemoveItem("ammo", 1);

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
