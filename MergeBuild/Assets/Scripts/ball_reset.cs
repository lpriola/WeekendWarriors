using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_reset : MonoBehaviour
{
    public GameObject pinball;
    private Vector3 initialPosition;
   
    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if(pinball.transform.position.z < (-7.0))
        {
            pinball.transform.position = initialPosition;
        }
    }
}
