using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;


    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
    }

    // Update is called once per frame
    public void switchCam(int i)
    {
        if (i==1)
        {
            cam1.enabled = true;
            cam2.enabled = false;
            i = 0;
        }
        if (i==2)
        {
            cam2.enabled = true;
            cam1.enabled = false;
            i = 1;
        }
    }
}
