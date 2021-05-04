using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
}
