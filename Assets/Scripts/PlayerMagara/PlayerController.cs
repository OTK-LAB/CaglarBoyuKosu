using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public Rigidbody rigid;
    public static PlayerController instance;

    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float rollScaleFactor = 0.2f;
    [SerializeField] private float rollDuration = 0.85f;

    private bool isGrounded;
    private bool isRolling;
    public bool isFinished;

    private Vector2 swipeStartPosition;
    private Vector2 startTouchPosition, swipeDelta;
    private bool isSwiping = false;

    public bool canMove = true;

    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

    }

    private float GetHorizontalInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            float touchX = Touchscreen.current.primaryTouch.position.x.ReadValue();
            float screenWidth = Screen.currentResolution.width;
            float normalizedX = touchX / screenWidth;
            return (normalizedX - 0.5f) * 2f; // Normalize and map to -1 to 1 range
        }

        return 0f;
    }

    private void Update()
    {
        Vector3 initialVelocity = new Vector3(rigid.velocity.x, rigid.velocity.y, 20);
        rigid.velocity = initialVelocity;

        if (canMove)
        {
            float horizontalInput = GetHorizontalInput();
            Vector3 movement = new Vector3(horizontalInput * moveSpeed, rigid.velocity.y, 20);
            rigid.velocity = movement;
        }

        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (!isSwiping)
            {
                startTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
                isSwiping = true;
            }

            swipeDelta = Touchscreen.current.primaryTouch.position.ReadValue() - startTouchPosition;
            // Eðer dikey hareket varsa
            if (Mathf.Abs(swipeDelta.y) > 50)
            {
                // Eðer ekrana dokunan parmak yukarý doðru hareket ettiyse
                if (swipeDelta.y > 0 && isGrounded && !isRolling)
                {
                    animator.SetBool("IsJumping", true);
                    isGrounded = false;
                    StartCoroutine(Jump());
                }
                // Eðer ekrana dokunan parmak aþaðý doðru hareket ettiyse
                else if (swipeDelta.y < 0 && !isRolling && isGrounded)
                {
                    animator.SetBool("IsRolling", true);
                    isRolling = true;
                    StartCoroutine(Roll());
                }

                ResetSwipe();
            }
        }
        else
        {
            ResetSwipe();
        }
    }

    private void ResetSwipe()
    {
        startTouchPosition = swipeDelta = Vector2.zero;
        isSwiping = false;
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
