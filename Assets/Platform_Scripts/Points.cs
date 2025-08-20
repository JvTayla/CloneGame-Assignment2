using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour //This script is added to every point, on the point object ensure that it has the FirePoint or WaterPoint tag as well as a collider.
{
   // public int iPoints;
    public GameObject AssignedPlayer;
    string playerType;
    public PointManager pointManager;
    // Start is called before the first frame update
    void Start()
    {
        playerType = AssignedPlayer.name;
        print(playerType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") && this.gameObject.CompareTag("FirePoint"))
        {
            pointManager.incPoints();
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Player2") && this.gameObject.CompareTag("WaterPoint"))
        {
            pointManager.incPointsTwo();
            Destroy(gameObject);
        }
    }
}
