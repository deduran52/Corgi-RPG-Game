using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    public GameObject thisObject;
    public GameObject guide;

    public float range =2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (guide.transform.position - thisObject.transform.position).sqrMagnitude < range * range)
        {
            Destroy(thisObject);
        }
        
    }
}
