using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public follow_ball cam1;
    

    // Start is called before the first frame update
    void Start()
    {
        cam1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(","))
        {
            cam1.gameObject.SetActive(true);
        }
        if (Input.GetKey("."))
        {
            cam1.gameObject.SetActive(false);
        }
    }
}
