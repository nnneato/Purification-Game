using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatus : MonoBehaviour
{

    bool tipped;
    GameObject whoTouched;
    GameObject[] soundManagers;
    SoundManagement soundManagement;
    GameObject gameLogic;
    GameLogic gameLogicScript;


    GameObject whoTipped;

    // TBD: name the sounds for each object?
    //string objSoundName;

    // Start is called before the first frame update
    void Start()
    {
        soundManagers = GameObject.FindGameObjectsWithTag("SOUND");
        soundManagement = soundManagers[0].GetComponent<SoundManagement>();
        gameLogic = GameObject.FindGameObjectWithTag("Logic");
        gameLogicScript = gameLogic.GetComponent<GameLogic>();


        tipped = false;
        //objSoundName = gameObject.name;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (tipped != true)
        {

            // If this object is not colliding with a piece of the level architecture...
            if (collision.gameObject.tag == "Tippable")
            {
                if (tipped != true)
                {
                    // Get the objectStatus script from the thing that tipped this item
                    for (int i = 0; i < gameLogicScript.objectStatuses.Length; i += 1)
                    {
                        if (gameLogicScript.objectStatuses[i].gameObject.name == collision.gameObject.name)
                        {
                            // Debug.Log("Found " + gameLogicScript.objectStatuses[i].gameObject.name + "'s script.");
                            whoTipped = gameLogicScript.objectStatuses[i].whoTouched;
                            break;
                        }
                    }
                }
            }


            if (collision.gameObject.tag == "Enemy")
            {
                whoTipped = collision.gameObject;
                whoTouched = collision.gameObject;
            }

            if (collision.gameObject.tag == "Player")
            {

                whoTipped = collision.gameObject;
                whoTouched = collision.gameObject;
            }
        }
    }

    public void ObjectTipped(GameObject anObj, GameObject tipper)
    {
        if (tipper.tag == "Enemy")
        {
            Debug.Log("ENEMY tipped/touched. No points will be awarded");
        }

        if (tipper.tag == "Player")
        {
            PlayerStats playerStats = tipper.gameObject.GetComponent<PlayerStats>();
            playerStats.itemsDisturbed += 1;
            Debug.Log(whoTipped.name + " has tipped over " + playerStats.itemsDisturbed + " items.");
        }

        tipped = true;
        TippedSound();
    }


    private void Update()
    {
        if (Vector3.Angle(transform.up, Vector3.up) > 45 || Vector3.Angle(transform.up, Vector3.up) < -25)
        {
            if (tipped != true)
            {
                if (whoTipped != null)
                {
                    ObjectTipped(gameObject, whoTipped);
                }
                if (whoTipped == null)
                {
                    Debug.Log("A mysterious force tipped this item. No points awarded.");
                    tipped = true;
                }
            }
        }
    }

    void TippedAnimation()
    {
        //tbd. Optional animation after tipping, depending on what was tipped. (e.g. glass breaking)
    }

    void TippedSound()
    {
        //tbd. Noise on tipped status.
        soundManagement.PlaySound("tippedGeneric");
    }
}
