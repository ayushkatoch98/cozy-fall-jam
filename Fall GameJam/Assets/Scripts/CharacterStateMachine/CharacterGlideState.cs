using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class CharacterGlideState : CharacterBaseState
{
    public CharacterGlideState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    private float glideGravScale = 1;

    private float tempYPos;
    private float tempGrav;

    public override void EnterState()
    {
        tempYPos = stateMachine.transform.position.y;
        tempGrav = stateMachine.gameObject.GetComponent<CustomGravity>().gravityStrength;

        stateMachine.gameObject.GetComponent<CustomGravity>().gravityStrength = glideGravScale;
        stateMachine.characterRigidbody.velocity = new Vector3(stateMachine.characterRigidbody.velocity.x, 0, stateMachine.characterRigidbody.velocity.z);

        stateMachine.glideDurationBar.gameObject.SetActive(true);
    }

    public override void UpdateState()
    {
        stateMachine.HandleMoving(stateMachine.glideSpeed);
        
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        if (stateMachine.isGrounded || stateMachine.currentGlideDuration <= 0)
        {
            if (verticalInput == 0 && horizontalInput == 0)
            {
                stateMachine.ChangeState(new CharacterIdleState(stateMachine));
            }

            if (Input.GetKey(stateMachine.sprintKey) && (verticalInput != 0 || horizontalInput != 0))
            {
                stateMachine.ChangeState(new CharacterWalkState(stateMachine));
            }

            if (verticalInput != 0 || horizontalInput != 0)
            {
                stateMachine.ChangeState(new CharacterWalkState(stateMachine));
            }

            stateMachine.currentGlideDuration = stateMachine.maxGlideDuration;
        }

        if (!stateMachine.isGrounded)
        {
            stateMachine.transform.position = new Vector3(stateMachine.transform.position.x, Mathf.Clamp(stateMachine.transform.position.y, Mathf.NegativeInfinity, tempYPos), stateMachine.transform.position.z);
            
            if (!Input.GetKey(stateMachine.jumpKey))
            {
                stateMachine.ChangeState(new CharacterJumpState(stateMachine));
            }
            else if (Input.GetKey(stateMachine.jumpKey))
            {
                stateMachine.currentGlideDuration -= Time.deltaTime;
            }
        }
        
    }

    public override void ExitState()
    {
        stateMachine.gameObject.GetComponent<CustomGravity>().gravityStrength = tempGrav;

        stateMachine.glideDurationBar.gameObject.SetActive(false);
    }
}