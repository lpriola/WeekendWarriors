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
        if((pinball.transform.position.z < (-7.0)) && (PlayerController.ballCount > 1))
        {
            pinball.transform.position = initialPosition;
            PlayerController.ballCount -= 1;
        }
        if (PlayerController.ballCount == 0)
        {
            DestroyImmediate(pinball);
        }
    }
}
