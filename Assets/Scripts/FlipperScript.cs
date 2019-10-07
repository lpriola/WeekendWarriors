using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public float rest_position = 0f;
    public float pressed_position = 45f;
    public float strength_hit = 10000f;
    public float flipper_damper = 150f;
    HingeJoint hinge;
    //public string input_name;
    private float ScreenWidth;

    void Start()
    {
        ScreenWidth = Screen.width;
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    void Update()
    {
        int i = 0;
        JointSpring spring = new JointSpring();
        spring.spring = strength_hit;
        spring.damper = flipper_damper;

        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                spring.targetPosition = pressed_position;
                hinge.spring = spring;
                hinge.useLimits = true;

            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                spring.targetPosition = pressed_position;
                hinge.spring = spring;
                hinge.useLimits = true;
            }
            else
            {
                spring.targetPosition = rest_position;
                hinge.spring = spring;
                hinge.useLimits = true;
            }
            ++i;

        }
    }
    /*
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = strength_hit;
        spring.damper = flipper_damper;

        if (Input.GetAxis(input_name) == 1)
        {
            spring.targetPosition = pressed_position;
        }

        else
        {
            spring.targetPosition = rest_position;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }
    */
}
