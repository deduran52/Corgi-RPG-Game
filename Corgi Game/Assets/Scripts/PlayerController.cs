using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody theRB;
    public float jumpForce;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // Grabs the Player Rigidbody, this is attached from the Unity side
        theRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        if(Input.GetButtonDown("Jump"))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, jumpForce,theRB.velocity.z);
        }
        anim.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Vertical"))+ Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
}
