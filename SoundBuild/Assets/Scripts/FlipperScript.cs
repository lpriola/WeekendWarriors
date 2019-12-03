using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public float rest_position = 0f;
    public float left_pressed_position = -45f;   // position of left flipper when touched
    public float right_pressed_position = 45f;   // position of right flipper when touched
    public float strength_hit = 9000f;
    public float flipper_damper = 150f;
    public HingeJoint hinge;
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

        // keeps flipper at rest postion
        spring.targetPosition = rest_position;
        hinge.spring = spring;
        hinge.useLimits = true;
         
        while (i < Input.touchCount)
        {
            // activates right flipper if right screen is touched
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                SoundManagerScript.PlaySound("Flippers");
                spring.targetPosition = right_pressed_position;
                hinge.spring = spring;
                hinge.useLimits = true;

            }

            // activates left flipper if left screen is touched
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                SoundManagerScript.PlaySound("Flippers");
                spring.targetPosition = left_pressed_position;
                hinge.spring = spring;
                hinge.useLimits = true;
            }
            ++i;

        }

    }

    /***********************************************/
    /************** Uses Keyboard ******************/
    /***********************************************/

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