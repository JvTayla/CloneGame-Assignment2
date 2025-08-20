using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour //Have an empty gameobject keep track of the points obtained in the level
{   
    
    public int iPointsOne;
    public int iPointsTwo;
    public TextMeshProUGUI pointsText; // Assign in Inspector

    void Start()
    {
        iPointsOne = 0;
        iPointsTwo = 0;
        UpdateText();
    }

    public void incPoints()
    {
        iPointsOne++;
        print("Current pts: " + iPointsOne);
        UpdateText();
    }

    public void incPointsTwo()
    {
        iPointsTwo++;
        UpdateText();
    }

    void UpdateText()
    {
        int pointTotal = iPointsOne + iPointsTwo;
        pointsText.text = "Gems: " + pointTotal;
    }
}
