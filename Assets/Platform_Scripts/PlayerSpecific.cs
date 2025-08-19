using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecific : MonoBehaviour
{
    [Header("Platform to move")]
    [Space(5)]
    [SerializeField] public Button platform;
    [SerializeField] public Transform Pos;

    [Header("Player to activate")]
    [Space(5)]
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        platform.pos = Pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == Player.name)
        {
            platform.Activate();
        }
        else
        {
            return;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == Player.name)
        {
            platform.Deactivate();
        }
        else
        {
            return;
        }
    }
}
