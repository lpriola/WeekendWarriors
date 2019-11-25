using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_reset : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 resetPosition;
    private Quaternion initialRotation;
    private float distance = 0.75f;  // change this depending on how "close" it needs to be

    void Start()
    {
        initialPosition = transform.position;
        //initialRotation = transform.rotation;
        resetPosition = new Vector3(0,0,-7);
    }

    void Update()
    {
        // Move the object upwards??
        //transform.Translate(Vector3.up * Time.deltaTime);

        // Reset the position if we are sufficiently close to (0,0,0)
        if (Vector3.Distance(transform.position, resetPosition) < distance)
        { 
            transform.position = initialPosition;
        }

    }
}
