using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour //Have an empty gameobject keep track of the points obtained in the level
{   
    
    public int iPoints;
    public TextMeshProUGUI pointsText; // Assign in Inspector

    void Start()
    {
        iPoints = 0;
        UpdateText();
    }

    public void incPoints()
    {
        iPoints++;
        print("Current pts: " + iPoints);
        UpdateText();
    }

    void UpdateText()
    {
        pointsText.text = "Gems: " + iPoints;
    }
}
