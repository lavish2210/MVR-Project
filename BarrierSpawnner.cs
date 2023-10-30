using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;  // Array of different obstacle prefabs
    public string coordinatesFilePath = "/home/sachin/Desktop/Brrr/College Docs/Sem7/MVR/FinalProject/Assets/carCoordinates.txt";    // The path to the text file containing coordinates

    private void Start()
    {
        List<Vector3> obstacleCoordinates = ReadCoordinatesFromFile(coordinatesFilePath);
        SpawnObstacles(obstacleCoordinates);
    }

    private List<Vector3> ReadCoordinatesFromFile(string filePath)
    {
        List<Vector3> coordinates = new List<Vector3>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            int a = 0;
            
            foreach (string line in lines)
            {
                a++;
                if(a%2!=0)continue;
                
                string[] parts = line.Split(',');

                if (parts.Length == 3)
                {
                    float x = float.Parse(parts[0]);
                    float y = float.Parse(parts[1]);
                    float z = float.Parse(parts[2]);
                    coordinates.Add(new Vector3(x, y, z));
                }
            }
        }
        else
        {
            Debug.LogError("Coordinates file not found: " + filePath);
        }

        return coordinates;
    }

    private void SpawnObstacles(List<Vector3> obstacleCoordinates)
    {
        foreach (Vector3 coordinate in obstacleCoordinates)
        {
            // Randomly select an obstacle prefab
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            if (obstaclePrefab != null)
            {
                // Instantiate the randomly selected obstacle at the specified coordinates
                Instantiate(obstaclePrefab, coordinate, Quaternion.identity);
            }
            else
            {
                Debug.LogError("No obstacle prefabs available.");
            }
        }
    }
}
