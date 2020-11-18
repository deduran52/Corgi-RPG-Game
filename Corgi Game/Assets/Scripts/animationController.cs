using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    Animator animator;
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    } // end of start

    // Changes the animation state based on conditions set inside
    void ChangeAnimationState(string newState)
    {
        // Stop the animation from interrupting itself
        if (currentState == newState) return;

        // reassign the current state
        currentState = newState;
        
    } // end of ChangeAnimationState
} // end of class
