using UnityEngine;
using System.Collections;

public class FeedbackClass : MonoBehaviour
{
	
	/*
	how haptic feedback works:  we can attach this script to the pinball itself,
	we have to change the tags of different objects to "vibrate" if we want the device to 
	vibrate when the ball hits certain things i.e. the flippers or bouncy objects.
	It would also be easy to keep score within this script
	*/
	
	public int ballScore = 0;
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "normal"){			
			ballScore += 5;
		}
		if(col.gameObject.tag == "bouncy"){
			ballScore += 25;
			Handheld.Vibrate();
		}
		if(col.gameObject.tag == "flipper"){
			Handheld.Vibrate();
		}
    }
}