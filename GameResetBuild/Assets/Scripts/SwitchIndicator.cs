using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchIndicator : MonoBehaviour
{
    public Material mat1;
    public Material mat2;
    private int currentMat;


    // Start is called before the first frame update
    void Start()
    {
        currentMat = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter()
    {

        if (currentMat == 0)
        {
            this.GetComponent<MeshRenderer>().material = mat2;
            currentMat = 1;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = mat1;
            currentMat = 0;
        }
    }

}
