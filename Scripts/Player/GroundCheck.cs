using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject player;
    public bool isGrounded;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (other.CompareTag("FloatingPlatform"))
        {
            isGrounded = true;
            player.transform.parent = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        if (other.CompareTag("FloatingPlatform"))
        {
            isGrounded = false;
            player.transform.parent = null;
        }
    }
}
