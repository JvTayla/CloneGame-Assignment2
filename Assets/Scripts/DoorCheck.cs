using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorCheck : MonoBehaviour
{
    public GameObject DoorClosed;
    public GameObject DoorOpen;
    public string requiredPlayerTag; // Set in Inspector: "Player1" or "Player2"
    public bool isOpen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name + " | Tag: " + collision.tag);

        if (collision.CompareTag(requiredPlayerTag))
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (!isOpen)
        {
            Debug.Log("Opening " + gameObject.name);
            DoorClosed.SetActive(false);
            DoorOpen.SetActive(true);
            isOpen = true;
        }
    }
}


