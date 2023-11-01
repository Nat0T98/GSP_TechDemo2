using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool CanJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Player Controls")]
    public KeyCode Jump = KeyCode.Space;

    [Header ("Grounded")]
    public float playerHeight;
    public LayerMask Ground;
    bool grounded;


    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    Vector3 MovementDir;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        CanJump = true;
    }

    private void Update()
    {
        // ground check
        //grounded = Physics.Raycast(transform.position + new Vector3(0, 0.05f, 0), Vector3.down, playerHeight * 0.5f + 0.3f, Ground);
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, Ground);

        PlayerInput();
        MoveSpeed();        
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(Jump) && CanJump && grounded)
        {
            CanJump = false;

            JumpKey();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

    }

    private void MovePlayer()
    {
        MovementDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
               
        if (grounded)
            rb.AddForce(MovementDir.normalized * moveSpeed * 10f, ForceMode.Force);
          
        else if (!grounded)
            rb.AddForce(MovementDir.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void MoveSpeed()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }                
    }

    private void JumpKey()
    {
        
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        CanJump = true;
    }
}