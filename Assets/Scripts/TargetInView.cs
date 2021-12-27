using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInView : MonoBehaviour
{
    bool addOnlyOnce;
    public GameObject gameLogic;
    private TargetingScript targetingScript;

    // Start is called before the first frame update
    void Start()
    {
        targetingScript = gameLogic.GetComponent<TargetingScript>();
        addOnlyOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (addOnlyOnce == true)
        {
            targetingScript.targetedNPCs.Add(gameObject);
            addOnlyOnce = false;
        }
    }
}
