using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabManager : MonoBehaviour
{
    private Transform tr;
    private GameObject grabObject;
    private bool isTouched = false;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("BALL"))
        {
            isTouched = true;
        }
    }
}
