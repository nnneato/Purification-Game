using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform enemyHitFX;
    public GameObject enemyHitFX_Long;
    public NavMeshAgent agent;
    public Animator animator;

    public float damageClock;
    public float damageInterval = .5f;
    private float movementClock;
    private float movementInterval = 2f;
    private int movementDir;
    private GameLogic gameLogic;

    public int hitPoints;

    public void Start()
    {
        damageClock = 0f;
        movementClock = 0f;
        hitPoints = 5;

        animator = this.GetComponentInChildren<Animator>();


        //switch (gameObject.name)
        //{
        //    case "EnemyTest":
        //        break;
        //}

        gameLogic = GameObject.FindWithTag("Logic").GetComponent<GameLogic>();

        enemyHitFX_Long.SetActive(false);
    }

    private void Update()
    {
        movementClock += Time.deltaTime;
        while (movementClock >= movementInterval)
        {
            MoveEnemy();
        }
    }

    public void EnemyNeutralized(GameObject killer)
    {
        gameObject.SetActive(false);
        SoundManagement soungMgr = GameObject.FindWithTag("SOUND").GetComponent<SoundManagement>();
        soungMgr.PlaySound("enemyDeath");
        if (killer.transform.root.tag == "Player")
        {
            PlayerStats killerStats = killer.transform.root.GetComponent<PlayerStats>();
            killerStats.enemiesNeutralized += 1;
            gameLogic.enemiesNeutralized += 1;
        }
        if (killer.transform.root.tag != "Player")
        {
            gameLogic.enemiesNeutralized += 1;
        }

        if (gameLogic.enemiesNeutralized == gameLogic.enemies.Count)
        {
            Debug.Log("All enemies eliminated");
            soungMgr.PlaySound("levelComplete");
            gameLogic.LevelComplete();
        }
    }

    void MoveEnemy()
    {

        movementDir = Random.Range(0, 4);

        switch (movementDir)
        {
            case 0:
                agent.SetDestination(agent.transform.position + Vector3.forward * 5);
                movementClock = 0f;
                break;

            case 1:
                agent.SetDestination(agent.transform.position + Vector3.back * 5);
                movementClock = 0f;
                break;

            case 2:
                agent.SetDestination(agent.transform.position + Vector3.left * 5);
                movementClock = 0f;
                break;

            case 3:
                agent.SetDestination(agent.transform.position + Vector3.right * 5);
                movementClock = 0f;
                break;
        }
    }

}
