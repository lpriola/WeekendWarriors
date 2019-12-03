using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{

    public Text scoreValue;
    //public Text BallText;
    //public Text BonusText;

    //private Rigidbody rb;
    private int ballCount;
    private int score;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //score = 0;
        //ballCount = 3;
        //setScoreText();
        // bonusText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        string scoreString = scoreValue.text;
        score = Int32.Parse(scoreString);

        if (this.gameObject.CompareTag("Bumper"))
        {
            score = score + 10;
            
        }
        else if (this.gameObject.CompareTag("Flipper"))
        {
            score = score + 30;

        }
        else if(this.gameObject.CompareTag("Indicator"))
        {
            score = score + 50;
        }
        else if(this.gameObject.CompareTag("Plunger"))
        {
            score = score + 100;
        }
        else if(this.gameObject.CompareTag("BlackHole"))
        {
            score = score + 500;
        }
        scoreValue.text = score.ToString();
    }

    void setScoreText()
    {
        //  ScoreText.text = "score: " + score.ToString ();
        if (score >= 200)
        {
            //    bonusText.text = "Time for a bonus round!";
        }
    }

    void setBallCount()
    {
        //ballCount.text = "BALL " + ballCount.ToString();
    }
}
