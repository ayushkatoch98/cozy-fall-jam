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
    public ParticleSystem jumpParticleSystem;
    public bool isGrounded;
    public bool hardLanding;

    [HideInInspector] public Rigidbody characterRigidbody;
    [HideInInspector] public Collider characterCollider;

    private void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        characterCollider = GetComponent<Collider>();

        ChangeState(new CharacterIdleState(this));

        currentAmountOfJumps = amountOfJumps;
    }

    private void Update()
    {
        currentState.UpdateState();

        Debug.Log(currentState);
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

    public void HandleMoving(float speed, float acceleration)
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
        Vector3 moveSpeed = moveDirection * speed;

        float currentSpeed = characterRigidbody.velocity.magnitude;

        if (currentSpeed < speed)
        {
            characterRigidbody.AddForce(moveSpeed / acceleration, ForceMode.VelocityChange);
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