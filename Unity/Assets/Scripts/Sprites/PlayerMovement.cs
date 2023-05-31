using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public GameObject attacking;

    public float runSpeed = 40f;
    public float jumpCooldown = 0.25f; // Jump cooldown time in seconds
    public float jumpTimer = 0f;    // Timer for tracking jump cooldown

    float horizontalMove = 0f;
    bool jump = false;
    public bool crouch = false;

    void Update()
    {
        if (!PauseScreen.gameIsPaused)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if(crouch == false)
            {
                if (Input.GetButtonDown("Jump") && jumpTimer <= 0)
                {
                    jump = true;
                    animator.SetBool("IsJumping", true);
                    jumpTimer = jumpCooldown;
                }
            }

            if(controller.canCrouch == true)
            {
                if (Input.GetButtonDown("Crouch"))
                {
                    crouch = true;
                    attacking.SetActive(false);
                }
                else if (Input.GetButtonUp("Crouch"))
                {
                    crouch = false;
                    attacking.SetActive(true);
                }
            }

            // Decrement the jump timer
            jumpTimer -= Time.deltaTime;
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                jump = false;
                animator.SetBool("IsJumping", false);
            }
            if(controller.canCrouch == true)
            {
                if (Input.GetButtonDown("Crouch"))
                {
                    crouch = false;
                    attacking.SetActive(false);
                }
                else if (Input.GetButtonUp("Crouch"))
                {
                    crouch = false;
                    attacking.SetActive(false);
                }
            }
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
