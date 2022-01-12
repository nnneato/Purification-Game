using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    [NonSerialized] public bool gamePlaying;
    public NPC_Dialog_Options dialog_Options;
    // bool inLevel;
    [NonSerialized] public bool gamePaused;
    [SerializeField] public ObjectStatus[] objectStatuses;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject enemy;
    CountdownTimer countdownTimer;
    [SerializeField] public int enemiesNeutralized = 0;

    GameObject[] players;

    private int numEnemies = 5;



    // Start is called before the first frame update
    void Start()
    {
        enemiesNeutralized = 0;
        gamePlaying = false;
        players = GameObject.FindGameObjectsWithTag("Player");
        objectStatuses = FindObjectsOfType<ObjectStatus>();
        countdownTimer = GameObject.FindWithTag("Timer").GetComponent<CountdownTimer>();

    }

    public void AddEnemy()
    {
        if(enemies.Any() != true)
        for (int i = 0; i < numEnemies; i++)
        {
            enemies.Add(Instantiate(enemy, new Vector3(1 * i, 1, 1), Quaternion.identity));
        } else
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(true);
                EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
                enemyBehavior.Start();
            }
        }
    }

    public void DestroySpawnedEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
    }

    public int CalculateScore(float timeElapsed, int itemsTipped)
    {
        int penalty = itemsTipped * 5;
        int finalScore = (int)timeElapsed - penalty;
        return finalScore;
    }

    public void LevelComplete()
    {
        countdownTimer.endingTime = countdownTimer.currentTime;
        gamePlaying = false;
        countdownTimer.timerOn = false;
        dialog_Options.inProgress = false;
        dialog_Options.levelComplete = true;
        foreach (GameObject player in players)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            int finalScore = CalculateScore(countdownTimer.endingTime, playerStats.itemsDisturbed);
            Debug.Log("Your final score is: " + finalScore);
            //Debug.Log(player.name + " tipped over " + playerStats.itemsDisturbed + " item(s).");
            //Debug.Log(player.name + " neutralized " + playerStats.enemiesNeutralized + " enemy/enemies.");
            ResetPlayerStats();
        }
    }

    public void ResetPlayerStats()
    {
        enemiesNeutralized = 0;
        foreach (GameObject player in players)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            playerStats.ResetItemsDisturbed();
            playerStats.ResetEnemiesNeutralized();
        }
    }

    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
    }
}
