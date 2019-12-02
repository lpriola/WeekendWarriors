using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRound : MonoBehaviour
{
    public GameObject pinball;

    private GameObject clone;
    private Vector3 appearPosition;
    private Vector3 resetPosition;
    private float distance = 0.75f;  // change this depending on how "close" it needs to be
    private List<GameObject> bonusList;

    // Start is called before the first frame update
    void Start()
    {
        appearPosition = new Vector3(3, (float)0.25, (float)-4.7);
        resetPosition = new Vector3(0, 0, -7);
    }

    // When enter black hole, extra ball created
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3((float)2.55, (float)0.26, (float)0.91);
        if (other.gameObject.CompareTag("Ball"))
        {
            clone = Instantiate(pinball);
            clone.transform.position = appearPosition;
            //bonusList.Add(clone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (GameObject bonusBall in bonusList)
        //{
        //    if (Vector3.Distance(bonusBall.transform.position, resetPosition) < distance)
        //    {
        //        GameObject.Destroy(bonusBall);
        //    }
        //}

    }
}
