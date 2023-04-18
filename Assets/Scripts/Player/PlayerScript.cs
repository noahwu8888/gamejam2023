using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal"); // Get the raw input value for horizontal movement
        moveInput.y = Input.GetAxisRaw("Vertical");  // Get the raw input value for vertical movement

        moveInput.Normalize();
        
        rb.velocity = new Vector3(moveInput.x * speed, rb.velocity.y, moveInput.y * speed);

        if(Input.GetButton("Fire3")){

        }
    }
    void doRoll(){
        
    }
}
