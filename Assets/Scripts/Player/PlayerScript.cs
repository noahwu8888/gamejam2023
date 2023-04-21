using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    #region General
    [SerializeField] private float speed = 5f;
    private Collider col;
    private Rigidbody rb;
    private Vector2 moveInput;

    private State state;
    private enum State
    {
        Normal,
        Rolling
    }

    #endregion

    #region Roll

    public bool isRolling;
    // speed multiplier while rolling
    [SerializeField] private float rollMultiplier = 1.5f;
    private Vector3 rollDirection;
    // time player spends rolling
    [SerializeField] private float rollLength = 3f;
    private float rollTimer;
    [SerializeField] private float rollCooldown = 1f;

    private float rollCooldownTimer;

    void doRoll(Vector3 direction)
    {
        if (rollTimer > 0)
        {
            isRolling = true;
            rb.velocity = direction * rollMultiplier;
            rollTimer -= Time.deltaTime;
        }
        else
        {
            isRolling = false;
            state = State.Normal;
        }
    }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        isRolling = false;
        state = State.Normal;

    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal"); // Get the raw input value for horizontal movement
        moveInput.y = Input.GetAxisRaw("Vertical");  // Get the raw input value for vertical movement
        moveInput.Normalize();

        if (rollCooldownTimer >= 0)
        {
            rollCooldownTimer -= Time.deltaTime;
        }

        Vector3 direction = new Vector3(moveInput.x * speed, rb.velocity.y, moveInput.y * speed);
        if (Input.GetButton("Jump") && rollCooldownTimer < 0 && rb.velocity != Vector3.zero)
        {
            rollTimer = rollLength;
            state = State.Rolling;
            rollDirection = direction;
        }
        switch (state)
        {
            case State.Normal:
                rb.velocity = direction;
                break;
            case State.Rolling:
                doRoll(rollDirection);
                rollCooldownTimer = rollCooldown;
                break;
        }
    }

}
