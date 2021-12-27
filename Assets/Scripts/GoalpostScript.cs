using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalpostScript : MonoBehaviour
{

    public GameObject playerRacer;
    GameObject player;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Use to mark who has reached the goal
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            Debug.Log("goal!");
            
        }
    }
}
