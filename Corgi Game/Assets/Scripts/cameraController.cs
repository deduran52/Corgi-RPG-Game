using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    // Start is called before the first frame update
 
        public Transform target;
        public Vector3 offsetPos;
        public float moveSpeed = 5f;
        public float turnSpeed = 10f;
        public float smoothSpeed = 0.5f;

        Quaternion targetRotation;
        Vector3 targetPos;
        private bool smoothRotation = false;


    

    // Update is called once per frame
    void Update()
    {
        moveWithTarget();
        LookAtTarget();

        if(Input.GetKeyDown(KeyCode.G) && !smoothRotation)
        {
            StartCoroutine("RotateAroundTarget", 45);
        }
        if(Input.GetKeyDown(KeyCode.H) && !smoothRotation)
        {
            StartCoroutine("RotateAroundTarget", -45);
        }

    }

    void moveWithTarget() 
    {
        targetPos = target.position +offsetPos;
        transform.position = Vector3.Lerp(transform.position,targetPos,moveSpeed * Time.deltaTime);
    }

    void LookAtTarget()
    {
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

    }
    
    IEnumerator RotateAroundTarget(float angle)
    {
        Vector3 vel = Vector3.zero;
        Vector3 targetOffsetPos = Quaternion.Euler(0,angle,0) *offsetPos;
        float dist = Vector3.Distance(offsetPos, targetOffsetPos);

        while(dist > 0.02f)
        {
            offsetPos = Vector3.SmoothDamp(offsetPos,targetOffsetPos,ref vel,smoothSpeed);
            dist = Vector3.Distance(offsetPos, targetOffsetPos);
            yield return null;
        }
        smoothRotation = false;
        offsetPos = targetOffsetPos;    
    }
    
}
