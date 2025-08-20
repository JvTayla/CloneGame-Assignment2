using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    private string thisTag;
    [Header("Platform to move")]
    [Space(5)]
   // [SerializeField] public Button platform;
    [SerializeField] public GameObject defaultPos;
    [SerializeField] public GameObject movedPos;

    [Header("Player to activate")]
    [Space(5)]
    [SerializeField] public string PlayerTag;
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
        if ((collision.CompareTag(PlayerTag)))
        {
            if (thisTag == "OnState")
            {
                defaultPos.SetActive(false);
                movedPos.SetActive(true);
            }
            else if (thisTag == "OffState")
            {
                defaultPos.SetActive(true);
                movedPos.SetActive(false);
            }
        }
    }
}
