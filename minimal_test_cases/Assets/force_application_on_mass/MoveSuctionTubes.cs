using UnityEngine;

public class MoveSuctionTubes : MonoBehaviour
{
    private Vector3 _startPosition; // initial position of magnet in the scene
    private float stride; // distance moved by magnet 

    void Start()
    {
        stride = 0.04f;
        _startPosition = transform.position;
        _startPosition += new Vector3(0, stride / 2, 0);
    }

    void FixedUpdate()
    {
        // sinusoidal translation in magnet's z axis
        transform.position = _startPosition + stride * (new Vector3(Mathf.Sin(5 * Time.time), Mathf.Sin(2 * Time.time), Mathf.Sin(9*Time.time)));
    }
}

