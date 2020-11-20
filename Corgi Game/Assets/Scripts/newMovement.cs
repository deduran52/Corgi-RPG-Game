using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class newMovement : MonoBehaviour {

    // Movement Variables
    public CharacterController controller;
    public Transform cam;
    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    // Animation Variables
    Animator animator;
    private string currentState;

    // Only runs at the start of launch
    void Start() {
        // Getting the animator
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame, mostly for movement
    void Update() {
        //-------------------------------------------------------------------------------
        //                        Jumping
        //-------------------------------------------------------------------------------
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //-------------------------------------------------------------------------------
        //                        Gravity
        //-------------------------------------------------------------------------------
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //-------------------------------------------------------------------------------
        //                        Walk
        //-------------------------------------------------------------------------------
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    // Function for checking current state of animation
    void ChangeAnimaitonState(string newState) {
        // Stop the same animaiton from interrupting itself
        if(currentState == newState) return;

        // play the animaiton
        animator.Play(newState);

        // Reassinging the current state
        currentState = newState;
    }




} // end of class