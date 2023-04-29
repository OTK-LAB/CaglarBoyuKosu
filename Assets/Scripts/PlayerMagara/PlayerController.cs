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

    public bool isGrounded;
    private bool isJumping;
    private bool isRolling;
    public bool isFinished;

    public bool canMove = true;
    public float moveSpeed = 12f;

    public void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();     
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            rigid.velocity = new Vector3(horizontalInput * moveSpeed, 0, 10);
        }
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer))
        {
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
            //Camera.main.GetComponent<CameraController>().StopFollowingPlayer();
        }

        if (Input.GetKeyDown(KeyCode.S) && !isRolling)
        {
            isRolling = true;
            StartCoroutine(Roll());
        }
    }

    IEnumerator Roll()
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        yield return new WaitForSeconds(0.5f);
        transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        isRolling = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    //void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground") && !isJumping)
    //    {
    //        Camera.main.GetComponent<CameraController>().enabled = true;
    //    }
    //}
}
