using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabManager : MonoBehaviour
{
    private GameObject grabObject;
    private FixedJoint joint;
    private bool isTouched = false;

    void Start()
    {
        joint = GetComponent<FixedJoint>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("BALL"))
        {
            isTouched = true;
            grabObject = coll.gameObject;
        }
    }

    void Update()
    {
        if (isTouched == false
            && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            
        }
    }
}
