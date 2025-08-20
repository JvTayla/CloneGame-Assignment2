using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour  //Goes on the button platform which moves a platform when pressed
{
    [Header("Platform to affect")] //Drag the platform to affect into this field.
    [Space(5)]
    [SerializeField] public Button platform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player1") || collision.CompareTag("Player2")))
        {
            platform.Activate();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player1") || collision.CompareTag("Player2")))
        {
            platform.Deactivate();
        }
    }
}
