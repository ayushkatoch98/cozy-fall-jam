using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    private CharacterBaseState currentState;

    [Header("Stats")]
    public float walkSpeed;
    public float sprintSpeed;
    public float jumpPower;
    [Space]
    public int amountOfJumps;

    [Header("Controls")]
    public KeyCode jumpKey;
    public KeyCode sprintKey;
    public KeyCode crouchKey;

    [HideInInspector] public Rigidbody characterRigidbody;
    [HideInInspector] public Collider characterCollider;

    [HideInInspector] public float verticalInput;
    [HideInInspector] public float horizontalInput;

    private void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        characterCollider = GetComponent<Collider>();

        ChangeState(new CharacterIdleState(this));
    }

    private void Update()
    {
        currentState.UpdateState();
    }

    public void ChangeState(CharacterBaseState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }

        currentState = newState;
        currentState.EnterState();
    }

    public void HandleMoving(float speed)
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
        Vector3 moveVelocity = moveDirection * speed;

        characterRigidbody.velocity = moveVelocity;
    }

    public bool IsGrounded()
    {
        float raycastDistance = 0.05f;
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance);
    }
}