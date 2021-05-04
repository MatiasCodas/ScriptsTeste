using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool isDead;
    public static int points = 0;
    public static int deathCount = 0;

    private void Start()
    {
        isDead = false;
        points = 0;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            isDead = true;
            deathCount++;
        }

        if (other.CompareTag("Collectable05"))
        {
            points += 5;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Collectable10"))
        {
            points += 10;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("FinishLine"))
        {
            GameController.Instance.Finish();
        }
    }

}
