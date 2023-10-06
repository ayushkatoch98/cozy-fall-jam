using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class CharacterStateMachine : MonoBehaviour
{
    private CharacterBaseState currentState;

    [Header("Stats")]
    public float walkSpeed;
    public float runSpeed;
    public float jumpPower;
    [Space]
    public int amountOfJumps;
    public int currentAmountOfJumps;

    [Header("Controls")]
    public KeyCode jumpKey;
    public KeyCode sprintKey;
    public KeyCode crouchKey;
    [Space]
    public ParticleSystem landingParticleSystem;
    public bool isGrounded;
    public bool hardLanding;

    [HideInInspector] public Rigidbody characterRigidbody;
    [HideInInspector] public Collider characterCollider;

    private Vector3 velocityXZ;

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
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector3 moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
        Vector3 moveSpeed = moveDirection * speed;

        float currentSpeed = characterRigidbody.velocity.magnitude;

        if (currentSpeed < speed)
        {
            characterRigidbody.AddForce(moveSpeed / 40, ForceMode.VelocityChange);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }
}