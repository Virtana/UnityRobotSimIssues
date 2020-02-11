using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DisplayJointAngle : MonoBehaviour
{
    public HingeJoint joint;
    public TextMesh text;
    public String header;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        String angle = joint.angle.ToString("F1");
        text.text = header + "\n" + angle;
    }
}

