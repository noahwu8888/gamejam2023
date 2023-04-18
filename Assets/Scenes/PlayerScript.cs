using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveDirection = Vector3.zero;    
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // Get the raw input value for horizontal movement
        float verticalInput = Input.GetAxisRaw("Vertical");  // Get the raw input value for vertical movement

        // Calculate the movement vector based on the input
        moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized();

        // Calculate the movement vector based on the input and camera's forward direction
        Vector3 forward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 right = Vector3.Scale(cameraTransform.right, new Vector3(1, 0, 1)).normalized;
        moveDirection = (forward * verticalInput + right * horizontalInput).normalized;


        // Adjust the movement vector to snap to 45-degree angles
        if (moveDirection.magnitude != 0){
            // Calculate the angle between the current movement vector and the X-axis
            float angle = Mathf.Atan2(moveDirection.z, moveDirection.x) * Mathf.Rad2Deg;

            // Round the angle to the nearest 45 degrees
            angle = Mathf.Round(angle / 45) * 45;

            // Convert the angle back to a vector
            moveDirection = Quaternion.Euler(0, angle, 0) * Vector3.forward;
        }
    }
    void FixedUpdate()
{

        // Set the rigidbody velocity to the movement direction multiplied by the speed
        rb.velocity = cameraTransform.TransformDirection(moveDirection) * speed;
    
}
}
