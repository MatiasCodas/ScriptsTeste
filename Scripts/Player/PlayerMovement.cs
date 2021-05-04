using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float jumpForce = 10f;
    public GroundCheck groundCheck;
    public Rigidbody2D rb;
    private Vector2 moveDir;
    private bool leftButton;
    private bool righttButton;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Player.isDead)
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            return;
        }

        MovePlayer();
    }

    public void MovePlayer(float input = 0)
    {
        input = Input.GetAxisRaw("Horizontal");

        if (leftButton) { input = -1; }
        if (righttButton) { input = 1; }

        moveDir = new Vector2(input * moveSpeed, rb.velocity.y);
        rb.AddForce(moveDir);

        if (rb.velocity.magnitude > maxSpeed) { rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed); }
    }

    public void RightButton(bool isPressed)
    {
        righttButton = isPressed;
    }

    public void LeftButton(bool isPressed)
    {
        leftButton = isPressed;
    }

    public void Jump()
    {
        if (!groundCheck.isGrounded) return;
        moveDir = new Vector2(0, jumpForce);
        rb.AddRelativeForce(moveDir, ForceMode2D.Impulse);
    }
}
