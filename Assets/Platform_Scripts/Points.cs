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
        if ((collision.CompareTag("Player1") || collision.CompareTag("Player2")))
        {
            if(this.gameObject.CompareTag("FirePoint") && collision.gameObject.name == "Player1 Anim")
            {
                // iPoints++;
                pointManager.incPoints();
               // print("Point collected");
                Destroy(gameObject);
            }
            else if(this.gameObject.CompareTag("WaterPoint") && collision.gameObject.name == "Player2 Anim")
            {
                pointManager.incPoints();
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }
    }
}
