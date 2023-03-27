using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public float jumpForce = 7f;
    public Rigidbody rigid;

    public LayerMask groundLayer;
    public float raycastDistance = 0.6f;

    private bool isGrounded;
    private bool isJumping;
    private bool isRolling;

    private bool canMove = true;

    public void Start()
    {
        animator = GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            if (!isRolling)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
            }
            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
            }

            if (canMove && isGrounded && !isRolling)
            {
                if (Input.GetKey("a"))
                {
                    GetComponent<Rigidbody>().AddForce(-950, 0, 0, ForceMode.Force);
                }
                else if (Input.GetKey("d"))
                {
                    GetComponent<Rigidbody>().AddForce(950, 0, 0, ForceMode.Force);
                }
            }
        }
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer)) {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
        else
        {
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            Camera.main.GetComponent<CameraController>().StopFollowingPlayer();
        }

        if (Input.GetKeyDown(KeyCode.S) && !isRolling)
        {
            isRolling = true;
            StartCoroutine(Roll());
        }
    }

    IEnumerator Roll()
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f); // karakteri yarı boyuta indir
        yield return new WaitForSeconds(0.5f); // yarım saniye bekle
        transform.localScale = new Vector3(0.25f, 0.25f, 0.25f); // karakteri eski haline getir
        isRolling = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            canMove = true;
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
