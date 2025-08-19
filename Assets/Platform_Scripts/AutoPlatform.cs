using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlatform : MonoBehaviour
{
    [Header("Positions platform moves between")]
    [SerializeField] private Transform pos;   // Target position
    private Vector2 originalPos;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 2f;

    private bool movingToTarget = true;

    void Start()
    {
        originalPos = transform.position;
    }

    void Update()
    {
        Vector2 target = movingToTarget ? pos.position : originalPos;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Check if we've reached the target (within small tolerance)
        if (Vector2.Distance(transform.position, target) < 0.01f)
        {
            movingToTarget = !movingToTarget; // Flip direction
        }
    }
}
