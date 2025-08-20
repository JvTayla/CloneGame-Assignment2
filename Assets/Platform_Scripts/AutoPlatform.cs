using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlatform : MonoBehaviour
{
    [Header("Positions platform moves between")]
    [SerializeField] private Transform[] points;   // Assign multiple points in Inspector
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 3f;  // Time to wait at each point

    private int currentPointIndex = 0;
    private bool isWaiting = false;

    void Update()
    {
        if (points.Length == 0 || isWaiting) return;

        // Move towards current target point
        Transform targetPoint = points[currentPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // Check if reached target
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.01f && !isWaiting)
        {
            // Snap to exact position (fixes shaking)
            transform.position = targetPoint.position;

            StartCoroutine(WaitAtPoint());
        }
    }

    private IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        // Go to next point (loops around)
        currentPointIndex = (currentPointIndex + 1) % points.Length;

        isWaiting = false;
    }
}
