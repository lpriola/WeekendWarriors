using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRound : MonoBehaviour
{
    public GameObject pinball;

    private GameObject clone;
    private Vector3 appearPosition;
    private List<GameObject> bonusList;

    // Start is called before the first frame update
    void Start()
    {
        appearPosition = new Vector3(3, (float)0.25, (float)-4.7);
        bonusList = new List<GameObject>();
    }

    // When enter black hole, extra ball created
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3((float)2.55, (float)0.26, (float)0.91);
        if (other.gameObject.CompareTag("Ball"))
        {
            clone = Instantiate(pinball);
            clone.transform.position = appearPosition;
            bonusList.Add(clone); //list of clones created
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (bonusList != null)
        {
            for (int i=0;i<bonusList.Count;i++)
            {
                if (bonusList[i].transform.position.z <= (-6.3))
                {
                    Destroy(bonusList[i].gameObject);        //destroy the extra ball (clone)
                    bonusList.Remove(bonusList[i]);
                }
            }
            
        }

    }
}
