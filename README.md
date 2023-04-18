# gamejam2023


Sebs Code For Movement: 

public float speed = 5f;
private Rigidbody2D rb;
private Vector2 moveDirection;

void Start()
{
    rb = GetComponent<Rigidbody2D>();
    moveDirection = Vector2.zero;
}

void Update()
{
    float horizontalInput = Input.GetAxisRaw("Horizontal");
    float verticalInput = Input.GetAxisRaw("Vertical");

    // Calculate the movement vector based on the input
    moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

    // Adjust the movement vector to snap to 45-degree angles
    if (moveDirection.magnitude != 0)
    {
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        angle = Mathf.Round(angle / 45) * 45;
        moveDirection = Quaternion.Euler(0, 0, angle) * Vector2.right;
    }
}

void FixedUpdate()
{
    rb.velocity = moveDirection * speed;
}
