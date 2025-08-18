using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    private string thisTag;
    [Header("Platform to move")]
    [Space(5)]
    [SerializeField] public Button platform;
    // Start is called before the first frame update
    void Start()
    {
        thisTag = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(thisTag == "OnState")
            {
                platform.Activate();
            }
            else if (thisTag == "OffState")
            {
                platform.Deactivate();
            }
        }
    }
}
