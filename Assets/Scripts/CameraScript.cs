using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; // the target to follow
    public float smoothing = 5f; // the smoothing factor
    public float cameraHeight = 10f; // the height of the camera above the target
    public float cameraDistance = 10f; // the distance between the camera and the target
    public LayerMask obstacleLayerMask; // the layer(s) to consider as obstacles
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

        // check for obstacles between the camera and the target position
        RaycastHit hit;
        if (Physics.Linecast(target.position, targetPosition, out hit, obstacleLayerMask))
        {
            // if there's an obstacle, move the camera to the hit point minus a small buffer distance
            transform.position = hit.point - (hit.normal * 0.2f);
        }
        else
        {
            // if there's no obstacle, smoothly move the camera towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }

        // set the camera's rotation to look at the target at the desired angle
        transform.LookAt(target);
    }
}