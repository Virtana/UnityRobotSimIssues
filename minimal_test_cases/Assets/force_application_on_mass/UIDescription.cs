using UnityEngine;
using System;

public class UIDescription : MonoBehaviour
{
    public GameObject magnet;
    public GameObject cuboid;
    public TextMesh text;
    public String stateDescription;
    public String massDescription;
    public String forceDescription;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        String force = magnet.GetComponent<AddForce>().forceStrength.ToString();
        String mass = cuboid.GetComponent<Rigidbody>().mass.ToString();
        text.text = stateDescription + "\n" + massDescription + mass + "\n" + forceDescription + force;
    }
}

