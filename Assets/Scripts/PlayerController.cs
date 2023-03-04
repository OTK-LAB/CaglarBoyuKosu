using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 7f;
    public Rigidbody rigid;

    public LayerMask groundLayer;
    public float raycastDistance = 0.6f;

    private bool isGrounded;
    public bool isJumping;

    private bool canMove = true; // Yeni bir değişken ekledik

    public void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (canMove) // Eğer hareket edebilirsek karakteri hareket ettiriyoruz
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void Update()
    {
        if (canMove && isGrounded) // Eğer hareket edebilirsek ve yerdeysek karakteri hareket ettiriyoruz
        {
            if (Input.GetKey("a"))
            {
                GetComponent<Rigidbody>().AddForce(-50, 0, 0, ForceMode.Force);
            }
            else if (Input.GetKey("d"))
            {
                GetComponent<Rigidbody>().AddForce(50, 0, 0, ForceMode.Force);
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer))
            isGrounded = true;
        else
            isGrounded = false;

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            Camera.main.GetComponent<CameraController>().StopFollowingPlayer();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            canMove = true; // Yere iner inmez tekrar hareket etmemizi sağlıyoruz
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isJumping)
        {
            Camera.main.GetComponent<CameraController>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "puan")
        {
            Destroy(other.gameObject);
        }
    }
}
