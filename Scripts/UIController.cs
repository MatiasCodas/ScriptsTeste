using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Advertisements;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text pointsText;
    public GameObject finalScreen;
    public TMP_Text finalTimeText;
    public TMP_Text finalPointsText;
    public Timer timer;
    public int points;
    public GameObject pauseScreen;

    private void Start()
    {
        pauseScreen.SetActive(GameController.isPaused);
    }

    private void Update()
    {
        if (Player.isDead || GameController.finished || GameController.isPaused) return;

        timerText.text = "Tempo: " + timer.timer.ToString("F0");

        if (points != Player.points)
        {
            points = Player.points;
            pointsText.text = "Pontos: " + points.ToString();
        }
    }

    public void PauseButton()
    {
        GameController.isPaused = !GameController.isPaused;
        pauseScreen.SetActive(GameController.isPaused);

        Time.timeScale = GameController.isPaused ? 0 : 1;
    }

    public void ShowFinishScreen()
    {
        finalScreen.SetActive(true);

        finalTimeText.text = "Tempo: " + timer.timer.ToString("F0");

        points = Player.points;
        finalPointsText.text = "Pontos: " + points.ToString();
    }

    public void BackMenuButton()
    {
        GameController.finished = false;
        AdsController.Instance.DisplayInterstitialAD();
        SceneManager.LoadScene("Menu");
    }
}
