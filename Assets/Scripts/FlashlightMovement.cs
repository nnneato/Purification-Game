using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightMovement : MonoBehaviour
{
    //[SerializeField] private Animator animator;
    //[SerializeField] float speed = 200;
    private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private Transform cam;
    private Camera camComponent;
    private Vector3 direction;
    private RaycastHit hit;
    int layermask = 1 << 8;


    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        camComponent = cam.GetComponent<Camera>();
        //animator = GetComponentInChildren<Animator>();

    }
    // Update is called once per frame
    void Update()
    {

        Ray ray = camComponent.ScreenPointToRay(Input.mousePosition);



        // set directional input values
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // set the direction by creating a new vector3
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Turn flashlight on or off
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Fire1");
        }

        // If player is moving in any direction
        if (direction.magnitude >= 0.1f)
        {
            // Rotate based on camera position
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
        {
            transform.LookAt(hit.point);
        }

    }
}

