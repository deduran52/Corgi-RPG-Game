using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
    float throwForce = 600;
    Vector3 objectPosition;
    float distance;

    public float range = 2;

    public GameObject item;
    public GameObject guide;
    public GameObject tempParent;
    public bool carrying = false;

    void Update() {

        if (carrying == false)
        {
            if (Input.GetButtonDown("Interact") && (guide.transform.position - transform.position).sqrMagnitude < range * range) 
            {
                pickup();
                carrying = true;
            }
        }
        else if (carrying == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                drop();
                carrying = false;
            }
        }

    }//end update

    void pickup()
 {
     item.GetComponent<Rigidbody>().useGravity = false;
     item.GetComponent<Rigidbody>().isKinematic = true;
     item.transform.position = guide.transform.position;
     item.transform.rotation = guide.transform.rotation;
     item.transform.parent = tempParent.transform;
 }
 void drop()
 {
     item.GetComponent<Rigidbody>().useGravity = true;
     item.GetComponent<Rigidbody>().isKinematic = false;
     item.transform.parent = null;
     item.transform.position = guide.transform.position;
 }

}
