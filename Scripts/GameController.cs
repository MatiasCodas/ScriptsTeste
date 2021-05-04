using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private bool restart = false;
    public static bool isPaused = true;
    public static bool finished = false;
    public UIController uiController;

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (Player.isDead && restart == false)
        {
            StartCoroutine(RestartScene());
        }
    }

    IEnumerator RestartScene()
    {
        restart = true;

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Game");

        if (Player.deathCount % 5 == 0 && Player.deathCount != 0)
        {
            AdsController.Instance.DisplayInterstitialAD();
            uiController.PauseButton();
        }
    }

    public void Finish()
    {
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
            {
                { "time", uiController.timer.timer},
                { "points", Player.points },
                { "deathCount", Player.deathCount }
            });

        finished = true;
        uiController.ShowFinishScreen();
    }
}
