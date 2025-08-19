using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour //Have an empty gameobject keep track of the points obtained in the level
{
    public int iPoints;
    // Start is called before the first frame update
    void Start()
    {
        iPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incPoints()
    {
        iPoints++;
        print("Current pts: "+ iPoints);
    }
}
