﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    //public static int score = 0;
    static int gameScore = 0;
    int currentSharkCount;
    int maxSharkCount;

    public float maxScaleX;

    // Use this for initialization
    void Start()
    {
        //maxScaleX = transform.localScale.x;
        maxScaleX = GetComponent<RectTransform>().transform.localScale.x;
        currentSharkCount = 0;

        GameObject sharksGO = GameObject.Find("Sharks");

        if (!sharksGO)
        {
            Debug.LogWarning("Create an Empty Gameobject and name it Sharks.  Put all sharks in it. ");
        }
        else
            maxSharkCount = sharksGO.transform.childCount;

        UpdateProgressBar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Reset()
    {
        //Debug.Log("ScoreReset");

        gameScore = 0;
    }

    public static int GetGameScore()
    {
        return gameScore;
    }

    public void AddToScore(int points)
    {
        gameScore += points;
        currentSharkCount += points;
        UpdateProgressBar();
  
    }

    private void UpdateProgressBar()
    {
        if (maxSharkCount > 0)
        {
            RectTransform rectTrans = GetComponent<RectTransform>();
//           Debug.Log("before: " + rectTrans.transform.localScale);

            // divide by 100 is it a percentage?
            float newx = ((float)currentSharkCount / (float)maxSharkCount) * maxScaleX / 100f;
            rectTrans.transform.localScale = new Vector3(newx, rectTrans.transform.localScale.y, rectTrans.transform.localScale.z);
//            Debug.Log("after: " + rectTrans.transform.localScale);
        }
        else
            Debug.LogError("maxSharkCount <= 0");  
     }
}
