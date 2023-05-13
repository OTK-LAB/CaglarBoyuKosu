using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // objenin hareket hızı
    public float leftBoundary = -5f; // hareketin başlayacağı sol sınır
    public float rightBoundary = 5f; // hareketin başlayacağı sağ sınır

    private float targetX; // hedef x pozisyonu

    private void Start()
    {
        // başlangıçta objenin rastgele bir x pozisyonuna yerleştirilmesi
        transform.position = new Vector3(Random.Range(leftBoundary, rightBoundary), transform.position.y, transform.position.z);
    }

    private void Update()
    {
        // objenin hareketi
        transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetX, moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);

        // hedef x pozisyonuna ulaşıldığında yeni bir hedef belirleme
        if (Mathf.Approximately(transform.position.x, targetX))
        {
            targetX = Random.Range(leftBoundary, rightBoundary);
        }
    }
}