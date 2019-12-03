using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_ball : MonoBehaviour
{
    public GameObject Pinball;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Pinball.transform.position + offset;
    }
}
