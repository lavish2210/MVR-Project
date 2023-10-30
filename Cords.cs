using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CarPositionRecorder : MonoBehaviour
{
    // public List<Vector3> carCoordinates;
<<<<<<< HEAD
    public float captureInterval = 1.0f;
=======
    public float captureInterval = 15.0f;
>>>>>>> 5bf37ec (Second commit)
    public string saveFileName = "/carCoordinates.txt";

    private float lastCaptureTime;

    void Start()
    {
        // carCoordinates = new List<Vector3>();
    }

    void Update()
    {
        if (Time.time - lastCaptureTime >= captureInterval)
        {
            Vector3 temp = transform.position;
            string filePath = Application.dataPath + saveFileName;
<<<<<<< HEAD
            Debug.Log(filePath);
            Debug.Log(temp);
            if(!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "The player blob visited these random coordinates: \n\n");
            }
                File.AppendAllText(filePath, "(" + temp.x + ", " + temp.y + ", " + temp.z + ")\n\n");
=======
            // Debug.Log(filePath);
            // Debug.Log(temp);
            // if(!File.Exists(filePath))
            // {
            //     File.WriteAllText(filePath, "The player blob visited these random coordinates: \n\n");
            // }

                File.AppendAllText(filePath, temp.x + ", " + temp.y + ", " + temp.z + "\n\n");
>>>>>>> 5bf37ec (Second commit)
             lastCaptureTime = Time.time;
        }
    }

    // public void SaveCoordinates()
    // {
    //     string data = JsonUtility.ToJson(carCoordinates);
    //     Debug.Log(data);
    //     string filePath = Path.Combine(Application.persistentDataPath, saveFileName);
    //     Debug.Log(filePath);
    //     // File.WriteAllText(filePath, data);
    // }
}
