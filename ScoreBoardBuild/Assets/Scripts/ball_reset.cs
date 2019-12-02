using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ball_reset : MonoBehaviour
{
    public GameObject gameOverText;
    public Text gameOverString;
    public GameObject shame;
    public Text scoreValue;
    public Text ballNum;

    private Vector3 initialPosition;
    private Vector3 resetPosition;
    private Quaternion initialRotation;
    private float distance = 0.75f;  // change this depending on how "close" it needs to be
    private int ballCount;
    private int finalScore;
    private int winningScore = 100000;

    void Start()
    {
        initialPosition = transform.position;
        //initialRotation = transform.rotation;
        resetPosition = new Vector3(0,0,-7);
        ballCount = 3;
        gameOverText.SetActive(false);
        shame.SetActive(false);
    }

    void Update()
    {
        // Reset the position if we are sufficiently close to (0,0,0)
        if (Vector3.Distance(transform.position, resetPosition) < distance)
        { 
            if (ballCount == 0)
            {
                finalScore = Int32.Parse(scoreValue.text);
                if (finalScore < winningScore)
                {
                    gameOverText.SetActive(true);
                    shame.SetActive(true);
                }
                else if (finalScore >= winningScore)
                {
                    gameOverString.text = "YOU WIN!";
                    gameOverText.SetActive(true);
                }
            }
            else
            {
                transform.position = initialPosition;
                ballCount = ballCount - 1;
                ballNum.text = ballCount.ToString();
            }
        }
    }
}
