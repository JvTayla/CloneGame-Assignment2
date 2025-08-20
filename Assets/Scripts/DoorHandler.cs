using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{


    [Header("References")]
    public DoorCheck[] doorcheck;  // assign Player1 + Player2 in Inspector
    public GameObject nextScreen;

    private bool isChecking = false; // prevent multiple coroutines

    private void Update()
    {
        if (!isChecking && doorcheck != null && doorcheck.Length >= 2)
        {
            if (doorcheck[0].isOpen && doorcheck[1].isOpen)
            {
                StartCoroutine(CheckDoor());
            }
        }
    }

    private IEnumerator CheckDoor()
    {
        isChecking = true; // block new coroutines
        Debug.Log("Both doors open, waiting 2 seconds...");
        yield return new WaitForSeconds(2f);
        nextScreen.SetActive(true);
        Debug.Log("Next screen activated!");
    }
}
