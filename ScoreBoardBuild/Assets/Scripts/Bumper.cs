using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float power = 20f;
    Rigidbody ball;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       ball = other.gameObject.GetComponent<Rigidbody>();
       ball.AddRelativeForce(power * Vector3.forward);
    }

    private void OnTriggerStay(Collider other)
    {
        ball = other.gameObject.GetComponent<Rigidbody>();
        ball.AddRelativeForce(power * Vector3.forward);
    }
}
