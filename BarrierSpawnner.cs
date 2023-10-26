using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public Transform carTransform;
    public float spawnOffset = 50.0f; // Adjust this value as needed
    public float spawnInterval = 1.5f;

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        // Get the car's current position
        Vector3 carPosition = carTransform.position;

        // Calculate the spawn position ahead of the car
        Vector3 spawnPosition = carPosition + carTransform.forward * spawnOffset;

        // Spawn the obstacle at the calculated position
        if (Time.time > timeSinceLastSpawn + spawnInterval)
        {
            // Debug.Log(carPosition);
            // Debug.Log(spawnPosition);
            SpawnObstacle(spawnPosition);
            timeSinceLastSpawn = Time.time;
        }
    }

    void SpawnObstacle(Vector3 position)
    {
        if (obstaclePrefabs.Count == 0)
        {
            Debug.LogWarning("No obstacle prefabs assigned.");
            return;
        }

        GameObject selectedObstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

        GameObject newObstacle = Instantiate(selectedObstaclePrefab, position, Quaternion.identity);
    }
}
