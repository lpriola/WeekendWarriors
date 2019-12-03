using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour
{
    float power;
    float minPower = 0f;            // min power for plunger
    public float maxPower = 100f;   // max power for plunger
    public Slider powerSlider;
    List<Rigidbody> ballList;
    bool ballReady;
    bool soundPlayed;
    private float ScreenWidth;      // sets screenwidth for touch
    public FlipperScript position;

    // sets power for plunger
    void Start()
    {
        powerSlider.minValue = minPower;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();
        soundPlayed = false;
    }

   
    void Update()
    {
        int i = 0;
        
        if (!soundPlayed) // plays theme music only once
        {
            SoundManagerScript.PlaySound("Initial");
            soundPlayed = true;
        }

        if (ballReady)
        {
            powerSlider.gameObject.SetActive(true);
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
        }
        powerSlider.value = power;
        
        if (ballList.Count > 0)
        {
            ballReady = true;

            // if user touches screen
            if (i < Input.touchCount)
            {
                if (power <= maxPower)
                {
                    power += 50 * Time.deltaTime;
                }
            }

            // if user untouches screen
            if (i == Input.touchCount)
            {   
                foreach (Rigidbody r in ballList)
                {
                    r.AddForce(power * Vector3.forward);
                }
            }
        }
        else
        {
            ballReady = false;
            power = minPower;
        }
    }

    // collides with ball
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
        }
        power = 0f;
    }

}
