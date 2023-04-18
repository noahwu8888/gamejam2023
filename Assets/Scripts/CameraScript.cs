using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; // the target to follow
    public float smoothing = 5f; // the smoothing factor

    private Vector3 offset; // the offset between the target and the camera

    void Start()
    {
        // calculate the offset between the target and the camera
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // calculate the target position based on the target and offset
        Vector3 targetPosition = target.position + offset;

        // smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
