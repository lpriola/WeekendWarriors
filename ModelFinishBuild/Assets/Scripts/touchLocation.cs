using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchLocation 
{
    public int touchID;
    public GameObject flipper;

    public touchLocation(int newTouchID, GameObject newflipper)
    {
        touchID = newTouchID;
        flipper = newflipper; 
    }

    
}
