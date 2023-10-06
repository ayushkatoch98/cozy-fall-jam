using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;        // Movement speed
    public float jumpForce = 10f;       // Jump force
    private bool isGrounded = false;    // Check if the character is grounded
    private Rigidbody rb;               // Reference to the Rigidbody component

    float horizontalInput;
    float verticalInput;
    bool jumpInput;
    void Start()
    {
        // Get the Rigidbody component attached to the character GameObject
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the character is grounded using a raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);

        // Handle player input for movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        jumpInput = Input.GetKeyDown(KeyCode.Space);



    }
    private void FixedUpdate()
    {
        // Calculate the movement direction
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Move the character using Rigidbody
        rb.velocity = new Vector3(movementDirection.x * moveSpeed, rb.velocity.y, movementDirection.z * moveSpeed);

        // Handle jumping
        if (isGrounded && jumpInput)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
