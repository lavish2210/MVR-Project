using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // Reference to the cube's Transform component
    public float smoothSpeed = 5.0f;

    private Vector3 transformPrevPosition;
    private Vector3 cameraVelocity;
    private Vector3 cameraAcceleration;
    private Vector3 cameraVelocityPrev;

    void Start()
    {
        transformPrevPosition = transform.position;
    }

    void FixedUpdate()
    {
        cameraVelocityPrev = cameraVelocity;

        cameraVelocity = transform.position - transformPrevPosition;
        transformPrevPosition = transform.position;

        // Calculate the camera's acceleration
        cameraAcceleration = cameraVelocity - cameraVelocityPrev;
        cameraVelocityPrev = cameraVelocity;

        if (target == null)
            return;

        // Calculate the desired camera position based on the cube's position
        Vector3 targetPosition = target.position;
        Vector3 desiredPosition = targetPosition - target.forward * 5.0f + Vector3.up * 3.0f; // Adjust the values to center the cube

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref cameraVelocity, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Make the camera look at the cube
        transform.LookAt(targetPosition);
    }
}