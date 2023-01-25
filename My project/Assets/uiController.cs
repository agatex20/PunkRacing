using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiController : MonoBehaviour
{
    public Text winnerText;
    public Text cowsText;
    public Text counterText;
    public Text resetText;
    public Text cowsText2;
    public Text resetText2;
    public GameOver gameOver;
    private bool finished = false;
    private float startTime;
    private int cows1=0;
    private int cows2=0;



    private void Start()
    {
        resetText.enabled = false;
        resetText2.enabled = false;
        gameOver.enabled = false;
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            float currentTime = Time.time - startTime;
            int minutes = (int)(currentTime / 60f);
            int seconds = (int)(currentTime % 60f);
            counterText.text = minutes.ToString("00") + ":" + seconds.ToString("");
        }
    }

    public void UpdateCowsText(TractorController tractorController)
    {
        if (!finished)
        {
            cows1++;
            cowsText.text = "Cows collected: " + cows1.ToString();
        }
    }

    public void Finish()
    {
        if (cows1 < cows2)
        {
            winnerText.text = "Player2 (Red) wins";
        }
        else
        {
            winnerText.text = "Player1 (Blue) wins";
        }
        finished = true; ;
        gameOver.enabled = true;
        gameOver.Setup();

    }

    public void showResetText()
    {
        if (!finished)
        {
            resetText.enabled = true;
        }
    }

    public void hideResetText()
    {
        resetText.enabled = false;
    }

    public void ResetGame()
    { 
        SceneManager.LoadScene(0);
    }

    public void UpdateCowsText2(TractorController2 tractorController2)
    {
        if (!finished)
        {
            cows2++;
            cowsText2.text = "Cows collected: " + cows2.ToString();
        }
    }

    public void Finish2()
    {
        if (cows2 < cows1)
        {
            winnerText.text = "Player1 (Blue) wins";
        }
        else
        {
            winnerText.text = "Player2 (Red) wins";
        }
        finished = true; ;
        gameOver.enabled = true;
        gameOver.Setup();

    }

    public void showResetText2()
    {
        if (!finished)
        {
            resetText2.enabled = true;
        }
    }

    public void hideResetText2()
    {
        resetText2.enabled = false;
    }


}
