using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public float forceStrength;
    public float RayDistance;

    // empty child object of Magnet - used to set the raycast begin point in world
    private Transform _tipTransform;
    
    void Start()
    {
        // set force strength
        if (forceStrength <= 0)
        {
            forceStrength = 5;
            Debug.Log("Set defualt force: " + forceStrength);
        }

        // set ray cast distance (max distance at which the code will check for a collision with rigidbody)
        if(RayDistance <= 0)
        {
            RayDistance = 1f;
            Debug.Log("Set defualt ray distance: " + RayDistance);
        }

        // get tip transform
        _tipTransform = gameObject.transform.Find("Tip");
        if (_tipTransform == null)
        {
            Debug.Log("The 'Tip' frame was not found!");
        }
    }

    void FixedUpdate()
    {
        // setup raycast
        Vector3 rayBeginInTip = Vector3.zero;
        Vector3 rayBeginInWorld = _tipTransform.TransformPoint(rayBeginInTip);
        Vector3 rayDirectionInWorld = _tipTransform.TransformDirection(Vector3.up); // ray is casted out in the positive y direction in tip frame

        // cast ray out from tip frame
        RaycastHit raycastHitInfo;
        bool hit = Physics.Raycast(rayBeginInWorld, rayDirectionInWorld, out raycastHitInfo, RayDistance);
        Debug.DrawRay(rayBeginInWorld, rayDirectionInWorld * RayDistance, Color.green, 1f, false);

        // get hit info
        Vector3 hitPointInWorld = raycastHitInfo.point;
        Rigidbody hitObject = raycastHitInfo.rigidbody;

        // apply force at hit point in direction of tip
        Vector3 force = -rayDirectionInWorld.normalized * forceStrength;
        hitObject.AddForceAtPosition(force, hitPointInWorld);
        Debug.DrawRay(hitPointInWorld, force, Color.blue, 1f, false);       
    }
}

