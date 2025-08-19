using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour  //Was initially for the buttons but add this to any platform you want to move
{
    [Header("Positions platform moves inbetween")]
    [Space(5)]
    [SerializeField] public Transform pos;
    public Vector2 originalpos;

    [Header("Movement Settings")]
    [Space(5)]
    private float speed = 1f;
    private bool bMove = false;
    // Start is called before the first frame update
    void Start()
    {
        originalpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (bMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, originalpos, speed * Time.deltaTime);
        }

    }

    public void Activate()
    {
        bMove = true;
    }

    public void Deactivate()
    {
        bMove = false;
    }




   

    
}
