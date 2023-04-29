using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;

    const string RUNNING_ANIMATION = "Running";
    const string RUNNING_JUMP_ANIMATION = "Running Jump";

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        bool speed = playerController.canMove;
        bool isGrounded = playerController.isGrounded;
        bool isRunningJumping = animator.GetCurrentAnimatorStateInfo(0).IsName(RUNNING_JUMP_ANIMATION);

        if (isRunningJumping)
        {
            animator.Play(RUNNING_JUMP_ANIMATION);
        }
        else if (speed)
        {
            animator.Play(RUNNING_ANIMATION);
        }
        else
        {
            animator.Play("Idle"); // Varsayýlan animasyon
        }

        if (Input.GetKeyDown(KeyCode.W) && !isGrounded)
        {
            animator.Play(RUNNING_JUMP_ANIMATION);
        }
    }

}
