using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class CharacterStateMachine : MonoBehaviour
{
    private CharacterBaseState currentState;

    [Header("Stats")]
    public float walkSpeed;
    public float runSpeed;
    public float glideSpeed;
    public float jumpPower;
    [Space]
    public int amountOfJumps;
    public float maxGlideDuration;

    [Header("Controls")]
    public KeyCode jumpKey;
    public KeyCode sprintKey;
    public KeyCode crouchKey;
    [Space]
    [SerializeField] private Material particleMaterial;
    public ParticleSystem landingParticleSystem;
    public ParticleSystem jumpParticleSystem;
    public ParticleSystem runParticleSystem;
    [Space]
    public float walkFOV;
    public float runFOV;
    [SerializeField] private float fovTransitionSpeed;
    [Space]
    public Slider glideDurationBar;
    public bool isGrounded;
    [HideInInspector] public bool hardLanding;
    [HideInInspector] public int currentAmountOfJumps;
    [HideInInspector] public float currentGlideDuration;

    [HideInInspector] public Rigidbody characterRigidbody;
    [HideInInspector] public Collider characterCollider;

    private void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        characterCollider = GetComponent<Collider>();

        ChangeState(new CharacterIdleState(this));

        currentAmountOfJumps = amountOfJumps;
        currentGlideDuration = maxGlideDuration;
        glideDurationBar.gameObject.SetActive(false);
    }

    private void Update()
    {
        currentState.UpdateState();
        glideDurationBar.value = currentGlideDuration / maxGlideDuration;
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
        Vector3 moveSpeed = moveDirection * speed;

        float currentSpeed = characterRigidbody.velocity.magnitude;

        if (currentSpeed < speed)
        {
            characterRigidbody.AddForce(moveSpeed / 50, ForceMode.VelocityChange);
        }
    }

    public IEnumerator ChangeFOV(float startFOV, float targetFOV)
    {
        float elapsedTime = 0;

        while (elapsedTime < fovTransitionSpeed)
        {
            float currentFOV = Mathf.Lerp(startFOV, targetFOV, elapsedTime / fovTransitionSpeed);
            Camera.main.fieldOfView = currentFOV;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Camera.main.fieldOfView = targetFOV;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}