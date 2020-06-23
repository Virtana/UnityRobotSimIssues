using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public float forceStrength;
    public float RayDistance;
    public bool DebugMode;
    public bool Manual;

    private Transform _tipTransform; // empty child object of Magnet - used to set the raycast begin point in world
    private Vector3 _startPosition; // initial position of magnet in the scene
    private float stride; // distance moved by magnet 
    
    void Start()
    {
        stride = 0.05f;
        DebugMode = false;
        _startPosition = transform.position;

        // get tip transform
        _tipTransform = gameObject.transform.Find("Tip");
        if (_tipTransform == null)
        {
            Debug.Log("The 'Tip' frame was not found!");
        }
    }

    void FixedUpdate()
    {
        if (!Manual)
        {
            // sinusoidal translation in magnet's z axis
            transform.position = _startPosition + stride * (new Vector3(0.0f, 0.0f, Mathf.Sin(Time.time)));
        }
        
        // setup raycast
        Vector3 rayBeginInTip = Vector3.zero;
        Vector3 rayBeginInWorld = _tipTransform.TransformPoint(rayBeginInTip);
        Vector3 rayDirectionInWorld = _tipTransform.TransformDirection(Vector3.up); // ray is casted out in the positive y direction in tip frame

        // cast ray out from tip frame
        RaycastHit raycastHitInfo;
        if(Physics.Raycast(rayBeginInWorld, rayDirectionInWorld, out raycastHitInfo, RayDistance))
        {
            if (DebugMode)
            {
                Debug.DrawRay(rayBeginInWorld, rayDirectionInWorld * RayDistance, Color.green, 1f, false);
            }

            // get hit info
            Vector3 hitPointInWorld = raycastHitInfo.point;
            Rigidbody hitObject = raycastHitInfo.rigidbody;
            if(hitObject != null)
            {
                // apply force at hit point in direction of tip
                Vector3 force = -rayDirectionInWorld.normalized * forceStrength;
                hitObject.AddForceAtPosition(force, hitPointInWorld);

                if (DebugMode)
                {
                    Debug.DrawRay(hitPointInWorld, force, Color.blue, 1f, false);
                }
            }
        } 
    }
}

