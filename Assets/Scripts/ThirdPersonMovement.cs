using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private Animator animator;
    [SerializeField] float speed = 200;
    private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private Transform cam;
    private Vector3 direction;


    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        animator = GetComponentInChildren<Animator>();
        playerRB = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update()
    {

        // set directional input values
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // set the direction by creating a new vector3
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        // If player is moving in any direction
        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("walk", true);

            // Rotate based on camera position
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Move the player
            playerRB.AddForce(moveDir * speed);
        }
        else
        {
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
        }

    }
}

