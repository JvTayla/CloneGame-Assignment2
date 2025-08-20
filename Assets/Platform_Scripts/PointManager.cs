using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour //Have an empty gameobject keep track of the points obtained in the level
{

    public int redPoints;

    public int bluePoints;
    public TextMeshProUGUI bluePointsText;
    public TextMeshProUGUI redPointsText;

    void Start()
    {
        redPoints = 0;
        bluePoints = 0;
        UpdateRedText();
        UpdateBlueText();
    }

    public void blueIncPoints()
    {
        bluePoints++;
        print("Current pts: " + bluePoints);
        UpdateBlueText();
    }

    public void redIncPoints()
    {
        redPoints++;
        print("Current pts: " + redPoints);
        UpdateRedText();
    }

    void UpdateRedText()
    {
        redPointsText.text = "Gems: " + redPoints;
    }
    
    void UpdateBlueText()
    {
        bluePointsText.text = "Gems: " + bluePoints;
    }
}
