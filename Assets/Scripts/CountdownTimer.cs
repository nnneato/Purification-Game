using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CountdownTimer : MonoBehaviour
{
    bool timerOn = false;

    public float currentTime;
    public float startingTime = 0f;
    public float endingTime = 0;

    public TextMeshProUGUI timerText;
    public GameObject logicStuff;
    private GameLogic gameLogic;

    public GameObject enemy;

    GameObject[] players;
    private PlayerStats playerStats;


    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        logicStuff = GameObject.FindWithTag("Logic");
        gameLogic = logicStuff.GetComponent<GameLogic>();
    }

    public void StartTimer()
    {
        gameLogic.enemies.Add(Instantiate(enemy));
        currentTime = startingTime;
        timerOn = true;
    }

    public void StopTimer()
    {
        timerOn = false;
        endingTime = currentTime;
        Debug.Log(endingTime.ToString("0") + " seconds elapsed. Timer stopped. Here are your stats:");
        foreach (GameObject player in players)
        {
            playerStats = player.GetComponent<PlayerStats>();
            Debug.Log(player.name + " knocked over " + playerStats.itemsDisturbed + " item(s).");
            Debug.Log(player.name + " neutralized " + playerStats.enemiesNeutralized + " enemy/enemies.");
            playerStats.ResetItemsDisturbed();
            playerStats.ResetEnemiesNeutralized();
        }

        foreach (GameObject enemy in gameLogic.enemies)
        {
            Destroy(enemy);
        }
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
