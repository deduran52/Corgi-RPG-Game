using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BrokenVector.LowPolyFencePack
{
    /// <summary>
    /// This class toggles the door animation.
    /// The gameobject of this script has to have the DoorController script which needs an Animator component
    /// and some kind of Collider which detects your mouse click applied.
    /// </summary>
    [RequireComponent(typeof(DoorController))]
	public class DoorToggle : MonoBehaviour
    {

        private DoorController doorController;
        private BoxCollider Box;
        
        void Awake()
        {
            doorController = GetComponent<DoorController>();
            Box = GetComponent<BoxCollider>();
        }

	    void OnMouseDown()
	    {
	        doorController.ToggleDoor();

            if (Box.enabled == true)
            {
                Box.enabled = false;
            }
            if (Box.enabled == false)
            {
                Box.enabled = true;
                doorController.ToggleDoor();
            }
            Debug.Log(Box.enabled);
        }

	}
}