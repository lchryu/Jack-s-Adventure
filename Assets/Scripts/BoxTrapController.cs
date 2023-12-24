using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrapController : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float initialSpeed = 2f;
    [SerializeField] private float accelerationRate = 0.1f; // Tốc độ tăng dần đều

    private float currentSpeed; // Tốc độ hiện tại

    private void Start()
    {
        currentSpeed = initialSpeed;
    }

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
            currentSpeed = initialSpeed; // Reset tốc độ khi chuyển đến điểm mới
        }

        // Tăng tốc độ nhanh dần
        currentSpeed += accelerationRate;

        // Di chuyển đối tượng với tốc độ hiện tại
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, currentSpeed * Time.deltaTime);
    }
}
