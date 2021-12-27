using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FlashlightMovement : MonoBehaviour
{

    public Camera cam;
    float mouseX;
    float mouseY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.LookAt(raycastHit.point);
        }

    }

    void RotateFlashlight(Vector3 mousePos)
    {


    }

}


