using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStates { Idle, Walking, Dead, Jump }
public class PlayerAnimations : MonoBehaviour
{
    public PlayerStates playerState = PlayerStates.Idle;
    public Animator animator;
    public PlayerMovement playerMovement;
    public GroundCheck groundCheck;

    private void Update()
    {
        if (Player.isDead)
        {
            Die();
            return;
        }

        Jump();

        if (playerMovement.rb.velocity.x != 0)
        {
            Walk();
        }
        else
        {
            Idle();
        }
    }

    private void Idle()
    {
        if (playerState != PlayerStates.Idle)
        {
            animator.SetBool("isWalking", false);
            playerState = PlayerStates.Idle;
        }
    }

    private void Jump()
    {
        animator.SetBool("isJumping", !groundCheck.isGrounded);

        if (!groundCheck.isGrounded && playerState != PlayerStates.Jump)
        {
            playerState = PlayerStates.Jump;
        }
    }

    private void Walk()
    {
        if (playerMovement.rb.velocity.x >= 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (playerState != PlayerStates.Walking)
        {
            animator.SetBool("isWalking", true);

            playerState = PlayerStates.Walking;
        }
    }

    public void Die()
    {
        if (playerState != PlayerStates.Dead)
        {
            animator.SetTrigger("Die");
            playerState = PlayerStates.Dead;
        }
    }

}
