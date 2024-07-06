using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float fixedHeight = 10f; // The fixed height above the target
    public float offsetZ = -20f;    // Offset for the z position
    public float cameraSpeed = 5f;

    private void LateUpdate()
    {
        // Calculate the target position with the fixed height and z offset
        Vector3 targetPosition = new Vector3(transform.position.x, fixedHeight, target.transform.position.z + offsetZ);

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed);
    }
}