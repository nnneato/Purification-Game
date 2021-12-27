using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [NonSerialized] public int itemsDisturbed;
    [NonSerialized] public int enemiesNeutralized;

    void Start()
    {
        itemsDisturbed = 0;
    }

    public void ResetItemsDisturbed()
    {
        itemsDisturbed = 0;
    }

    public void ResetEnemiesNeutralized()
    {
        enemiesNeutralized = 0;
    }
}
