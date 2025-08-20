using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{

    [Header("References")]
    public DoorCheck[] doorcheck;  // assign in Inspector
    public GameObject nextScreen;

    private void Update()
    {
        CheckDoor();
    }
    public void CheckDoor()
    {
        if (doorcheck != null && doorcheck.Length >= 2)
        {
            // Assuming doorcheck[0] = player1, doorcheck[1] = player2
            if (doorcheck[0].isOpen && doorcheck[1].isOpen)
            {
                nextScreen.SetActive(true);
            }
        }
    }
}
