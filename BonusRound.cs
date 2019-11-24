using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRound : MonoBehaviour
{
    public GameObject pinball;
    private GameObject clone;
    private Vector3 appearPosition;

    // Start is called before the first frame update
    void Start()
    {
        appearPosition = new Vector3(1, (float)0.15, (float)-4.35);
    }

    // When enter black hole, extra ball created
    private void OnTriggerEnter(Collider other)
    {
        pinball.transform.position = new Vector3((float)-2.0, (float)0.1, (float)4.7);
        if (other.gameObject.CompareTag("Ball"))
        {
            clone = Instantiate(pinball);
            clone.transform.position = appearPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(clone.transform.position.z <= (-6.0))
        {
            DestroyImmediate(clone);
        }
       
    }
}
