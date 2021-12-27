using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform enemyHitFX;
    public GameObject enemyHitFX_Long;
    private Transform[] childComponents;
    private GameObject camObj;
    private Camera cam;
    public NavMeshAgent agent;

    private float damageClock;
    private float damageInterval = .5f;
    private float movementClock;
    private float movementInterval = 2f;
    private int movementDir;

    public int hitPoints;

    private void Start()
    {
        damageClock = 0f;
        movementClock = 0f;
        hitPoints = 5;


        //switch (gameObject.name)
        //{
        //    case "EnemyTest":
        //        break;
        //}

        camObj = GameObject.FindGameObjectWithTag("MainCamera");
        cam = camObj.GetComponent<Camera>();

        childComponents = GetComponentsInChildren<Transform>();
        enemyHitFX_Long = gameObject.transform.GetChild(0).gameObject;

    }

    private void Update()
    {
        movementClock += Time.deltaTime;
        while (movementClock >= movementInterval)
        {
            MoveEnemy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(enemyHitFX, transform.position, transform.rotation);
        enemyHitFX_Long.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (hitPoints != 0)
        {
            damageClock += Time.deltaTime;
            while (damageClock >= damageInterval)
            {
                hitPoints -= 1;
                damageClock -= damageInterval;
            }
        }

        if (hitPoints <= 0)
        {
            EnemyNeutralized(other);
        }
    }

    void EnemyNeutralized(Collider killer)
    {
        Destroy(gameObject);
        PlayerStats killerStats = killer.transform.root.GetComponent<PlayerStats>();
        killerStats.enemiesNeutralized += 1;
    }

    void MoveEnemy()
    {

        movementDir = Random.Range(0, 4);

        switch (movementDir)
        {
            case 0:
                agent.SetDestination(agent.transform.position + Vector3.forward * 2);
                movementClock = 0f;
                break;

            case 1:
                agent.SetDestination(agent.transform.position + Vector3.back * 2);
                movementClock = 0f;
                break;

            case 2:
                agent.SetDestination(agent.transform.position + Vector3.left * 2);
                movementClock = 0f;
                break;

            case 3:
                agent.SetDestination(agent.transform.position + Vector3.right * 2);
                movementClock = 0f;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enemyHitFX_Long.SetActive(false);
    }
}
