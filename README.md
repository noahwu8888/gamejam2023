# gamejam2023

Sebs Experimental Code 

Movement:

```csharp
public float speed = 5f;                    // Movement speed (adjustable in the editor)
private Rigidbody2D rb;                    // Reference to the Rigidbody2D component
private Vector2 moveDirection;             // Current movement direction

void Start()
{
    rb = GetComponent<Rigidbody2D>();     // Get the reference to the Rigidbody2D component
    moveDirection = Vector2.zero;          // Initialize the movement direction to zero (no movement)
}

void Update()
{
    float horizontalInput = Input.GetAxisRaw("Horizontal");    // Get the raw input value for horizontal movement
    float verticalInput = Input.GetAxisRaw("Vertical");        // Get the raw input value for vertical movement

    // Calculate the movement vector based on the input
    moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

    // Adjust the movement vector to snap to 45-degree angles
    if (moveDirection.magnitude != 0)
    {
        // Calculate the angle between the current movement vector and the X-axis
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

        // Round the angle to the nearest 45 degrees
        angle = Mathf.Round(angle / 45) * 45;

        // Convert the angle back to a vector
        moveDirection = Quaternion.Euler(0, 0, angle) * Vector2.right;
    }
}

void FixedUpdate()
{
    // Set the rigidbody velocity to the movement direction multiplied by the speed
    rb.velocity = moveDirection * speed;
}
