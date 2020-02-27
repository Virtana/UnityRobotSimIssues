using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Text : MonoBehaviour
{
    public GameObject magnet;
    public TextMesh text;
    public String stateDescription;
    public String constrainedDescription;
    public String forceDescription;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        String force = magnet.GetComponent<AddForce>().forceStrength.ToString("F1");
        text.text = stateDescription + "\n" + constrainedDescription + "\n" + forceDescription + "\n" + force;
    }
}

