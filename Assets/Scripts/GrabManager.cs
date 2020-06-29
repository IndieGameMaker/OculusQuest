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
            joint.connectedBody = grabObject.GetComponent<Rigidbody>();
        }

        if (isTouched == true
            && OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            //오른쪽 컨트롤러의 속도 산출
            Vector3 _velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
            grabObject.GetComponent<Rigidbody>().velocity = _velocity;
            joint.connectedBody = null;
            isTouched = false;            
        }
        //헵틱 효과
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
        }

        
    }
}
