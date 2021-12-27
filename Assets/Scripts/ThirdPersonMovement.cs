using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Rigidbody playerRB;
    public float speed = 200;
    public Animator animator;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    private bool carrying;
    private bool running;
    private Vector3 direction;


    private void Start()
    {
        carrying = false;
        running = false;
    }
    // Update is called once per frame
    void Update()
    {
        // set directional input values
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // set the direction by creating a new vector3
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Check if player is carrying something
        if (Input.GetKeyDown(KeyCode.H))
        {
            IsCarrying(carrying);
        }

        // Check if player is running
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            RunningCheck(running);
        }

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
            running = false;
        }



        void IsCarrying(bool answer)
        {
            if (answer != true)
            {
                speed = 150;
                animator.SetLayerWeight(1, 1);
                carrying = true;
                Debug.Log(carrying);
            }
            if (answer != false)
            {
                speed = 200;
                animator.SetLayerWeight(1, 0);
                carrying = false;
                Debug.Log(carrying);
            }
        }


        // Bug/feature: You keep running even if you let go of shift...
        void RunningCheck(bool answer)
        {
            if (answer != true)
            {
                speed = 400;
                animator.SetBool("run", true);
                running = true;
            }
            else
            {
                speed = 200;
                animator.SetBool("run", false);
                running = false;
            }

        }
    }
}

