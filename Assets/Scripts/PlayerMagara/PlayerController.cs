using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public Rigidbody rigid;

    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float rollScaleFactor = 0.2f;
    [SerializeField] private float rollDuration = 0.85f;

    private bool isGrounded;
    private bool isRolling;
    private bool isFinished;

    public bool canMove = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            Vector3 movement = new Vector3(horizontalInput * moveSpeed, rigid.velocity.y, 20);
            rigid.velocity = movement;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && !isRolling)
        {
            animator.SetBool("IsJumping", true);
            isGrounded = false;
            StartCoroutine(Jump());
        }

        if (Input.GetKeyDown(KeyCode.S) && !isRolling && isGrounded)
        {
            animator.SetBool("IsRolling", true);
            isRolling = true;
            StartCoroutine(Roll());
        }
    }

    private IEnumerator Jump()
    {
        // Yerçekimini geçici olarak azalt
        rigid.useGravity = false;
        Vector3 jumpVelocity = Vector3.up * jumpForce;
        rigid.velocity += jumpVelocity;

        yield return new WaitForSeconds(0.5f);

        Vector3 downVelocity = Vector3.down * 2f * jumpForce;
        rigid.velocity += downVelocity;

        yield return new WaitForSeconds(0.5f);

        // Yerçekimini tekrar etkinleþtir
        rigid.useGravity = true;
        animator.SetBool("IsJumping", false);
    }


    private IEnumerator Roll()
    {
        transform.localScale = new Vector3(rollScaleFactor, rollScaleFactor, rollScaleFactor);
        yield return new WaitForSeconds(rollDuration);
        transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        animator.SetBool("IsRolling", false);
        isRolling = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
