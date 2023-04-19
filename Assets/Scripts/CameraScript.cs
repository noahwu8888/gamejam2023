using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; // the target to follow
    public float smoothing = 5f; // the smoothing factor
    public float cameraHeight = 10f; // the height of the camera above the target
    public float cameraDistance = 10f; // the distance between the camera and the target

    private Vector3 offset; // the offset between the target and the camera

    void Start()
    {
        // Calculate the offset between the target and the camera, taking into account the desired orientation
        offset = new Vector3(0f, cameraHeight, -cameraDistance);

    }

    void FixedUpdate()
    {
        // calculate the target position based on the target and offset
        Vector3 targetPosition = target.position + offset;

        // smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);

        // set the camera's rotation to look at the target at the desired angle
        transform.LookAt(target);
    }
}