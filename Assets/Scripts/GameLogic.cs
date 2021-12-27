using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    bool gamePlaying;
    // bool inLevel;
    [NonSerialized] public bool gamePaused;
    [SerializeField] public ObjectStatus[] objectStatuses;
    public List<GameObject> enemies = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        objectStatuses = FindObjectsOfType<ObjectStatus>();
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
