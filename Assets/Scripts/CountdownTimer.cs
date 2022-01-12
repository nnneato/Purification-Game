using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CountdownTimer : MonoBehaviour
{
    public bool timerOn = false;

    public float currentTime;
    public float startingTime = 0f;
    public float endingTime = 0;

    public TextMeshProUGUI timerText;
    public GameLogic gameLogic;
    public Animator door;

    public void StartTimer()
    {
        door.Play("Open_Door");
        gameLogic.gamePlaying = true;
        gameLogic.AddEnemy();
        currentTime = startingTime;
        timerOn = true;
    }

    public void StopTimer()
    {
        gameLogic.gamePlaying = false;
        timerOn = false;
        endingTime = currentTime;
        Debug.Log("Timer stopped.");
        gameLogic.DestroySpawnedEnemies();
        gameLogic.ResetPlayerStats();
    }

    void Update()
    {
        if (gameLogic.gamePaused != true && timerOn == true)
        {
            currentTime += 1 * Time.deltaTime;
            timerText.SetText(currentTime.ToString("0"));
        }
    }
}
