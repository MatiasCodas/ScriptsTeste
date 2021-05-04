using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 0;

    private void Update()
    {
        if (Player.isDead || GameController.finished || GameController.isPaused) return;
        timer += Time.deltaTime;
    }
}
