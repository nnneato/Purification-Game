using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatus : MonoBehaviour
{

    public bool tipped = false;
    public GameObject whoTouched;
    public GameObject whoTipped;
    GameObject[] soundManagers;
    SoundManagement soundManagement;

    // TBD: name the sounds for each object?
    //string objSoundName;

    // Start is called before the first frame update
    void Start()
    {
        soundManagers = GameObject.FindGameObjectsWithTag("SOUND");
        soundManagement = soundManagers[0].GetComponent<SoundManagement>();

        tipped = false;
        //objSoundName = gameObject.name;
    }


    public void ObjectTipped(GameObject anObj, GameObject tipper)
    {
        if (tipper.tag == "Enemy")
        {
            //Debug.Log("ENEMY tipped/touched. No points will be awarded");
        }

        if (tipper.tag == "Player")
        {
            PlayerStats playerStats = tipper.gameObject.GetComponent<PlayerStats>();
            playerStats.itemsDisturbed += 1;
            //Debug.Log(whoTipped.name + " has tipped over " + playerStats.itemsDisturbed + " items.");
        }

        tipped = true;
        TippedSound();
    }


    private void Update()
    {
        if (Vector3.Angle(transform.up, Vector3.up) > 45 || Vector3.Angle(transform.up, Vector3.up) < -45)
        {
            if (tipped != true)
            {
                if (whoTipped)
                {
                    ObjectTipped(gameObject, whoTipped);
                }
                else if (whoTouched)
                {
                    ObjectTipped(gameObject, whoTouched);
                }
                else
                {
                    //Debug.Log("A mysterious force tipped this item. No points awarded.");
                    tipped = true;

                }
            }
        }
    }

    void TippedSound()
    {
        //tbd. Noise on tipped status.
        soundManagement.PlaySound("tippedGeneric");
    }
}
