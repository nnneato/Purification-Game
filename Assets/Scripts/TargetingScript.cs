using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class TargetingScript : MonoBehaviour
{
    public List<GameObject> targetedNPCs = new List<GameObject>();
    public Component[] childTransforms;
    public GameObject targetMarker; //icon
    public GameObject activeTarget;
    public int activeTarNum = 0;
    public Camera mCamera;

    private void Start()
    {

    }

    private void Update()
    {
        //cycle up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetMarker.SetActive(false);
            CheckForIncrease(activeTarNum);
            activeTarget = targetedNPCs[activeTarNum];
            targetMarker = activeTarget.GetComponentsInChildren<Transform>(true).Last().gameObject;
            targetMarker.SetActive(true);
            Debug.Log(activeTarget + " is the active target");

        }

        //cycle down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetMarker.SetActive(false);
            CheckForDecrease(activeTarNum);
            activeTarget = targetedNPCs[activeTarNum];
            targetMarker = activeTarget.GetComponentsInChildren<Transform>(true).Last().gameObject;
            targetMarker.SetActive(true);
            Debug.Log(activeTarget + " is the active target");
        }

    }

    void CheckForIncrease(int currentNum)
    {
        if ((currentNum + 1) < targetedNPCs.Count)
        {
            activeTarNum += 1;
            Debug.Log("Active target number increased");
        }
    }

    void CheckForDecrease(int currentNum)
    {
        if ((currentNum - 1) >= 0)
        {
            activeTarNum -= 1;
            Debug.Log("Active target number decreased");
        }
    }
}
