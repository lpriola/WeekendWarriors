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
    public GameObject resetButton;
    public Text scoreValue;
    public Text ballNum;
    public Material matOff;
    public GameObject indicator1;
    public GameObject indicator2;
    public GameObject indicator3;
    public GameObject indicator4;
    public GameObject indicator5;
    public GameObject indicator6;
    public GameObject indicator7;
    public GameObject indicator8;
    public GameObject indicator9;

    private Vector3 initialPosition;
    private Vector3 resetPosition;
    private Quaternion initialRotation;
    private float distance = 0.75f;  // change this depending on how "close" it needs to be
    private int ballCount;
    private int finalScore;
    private int winningScore = 1500;
  
    public void Start()
    {
        initialPosition = transform.position;
        //initialRotation = transform.rotation;
        resetPosition = new Vector3(0,0,-7);
        ballCount = 3;
        gameOverText.SetActive(false);
        shame.SetActive(false);
        resetButton.SetActive(false);
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
                    gameOverString.text = "GAME OVER";
                    gameOverText.SetActive(true);
                    shame.SetActive(true);
                    resetButton.SetActive(true);
                }
                else if (finalScore >= winningScore)
                {
                    gameOverString.text = "YOU WIN!";
                    gameOverText.SetActive(true);
                    resetButton.SetActive(true);
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

    public void gameReset()
    {
        indicator1.GetComponent<MeshRenderer>().material = matOff;
        indicator2.GetComponent<MeshRenderer>().material = matOff;
        indicator3.GetComponent<MeshRenderer>().material = matOff;
        indicator4.GetComponent<MeshRenderer>().material = matOff;
        indicator5.GetComponent<MeshRenderer>().material = matOff;
        indicator6.GetComponent<MeshRenderer>().material = matOff;
        indicator7.GetComponent<MeshRenderer>().material = matOff;
        indicator8.GetComponent<MeshRenderer>().material = matOff;
        indicator9.GetComponent<MeshRenderer>().material = matOff;
        this.transform.position = initialPosition;
        scoreValue.text = "0";
        ballNum.text = "3";
        resetButton.SetActive(false);
        gameOverText.SetActive(false);
        shame.SetActive(false);
        ballCount = 3;
    }

}

