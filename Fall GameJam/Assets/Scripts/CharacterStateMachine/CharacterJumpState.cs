using System.Data;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterJumpState : CharacterBaseState
{
    public CharacterJumpState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void EnterState()
    {
        if (stateMachine.isGrounded)
        {
            Jump(1);
            stateMachine.isGrounded = false;
        }
    }

    public override void UpdateState()
    {
        if (Input.GetKey(stateMachine.sprintKey))
        {
            stateMachine.HandleMoving(stateMachine.runSpeed);
        }
        else
        {
            stateMachine.HandleMoving(stateMachine.walkSpeed);
        }

        if (stateMachine.isGrounded)
        {
            if (stateMachine.hardLanding)
            {
                stateMachine.hardLanding = false;
                stateMachine.landingParticleSystem.Play();
            }
            stateMachine.currentAmountOfJumps = stateMachine.amountOfJumps;
            HandleStateChanges();
        }
        else if (!stateMachine.isGrounded)
        {
            Vector3 rbVelocity = stateMachine.characterRigidbody.velocity;
            if (rbVelocity.y <= -20)
            {
                stateMachine.hardLanding = true;
            }

            if (stateMachine.currentAmountOfJumps > 0 && Input.GetKeyDown(stateMachine.jumpKey))
            {
                stateMachine.jumpParticleSystem.Play();
                Jump(1.5f);
            }
            else if (stateMachine.currentAmountOfJumps == 0 && Input.GetKeyDown(stateMachine.jumpKey))
            {
                stateMachine.ChangeState(new CharacterGlideState(stateMachine));
            }
        }
    }

    public override void ExitState()
    {
        
    }

    private void HandleStateChanges()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        if (verticalInput != 0 || horizontalInput != 0)
        {
            stateMachine.ChangeState(new CharacterWalkState(stateMachine));
        }

        if (Input.GetKey(stateMachine.sprintKey) && (verticalInput != 0 || horizontalInput != 0))
        {
            stateMachine.ChangeState(new CharacterRunState(stateMachine));
        }

        if (verticalInput == 0 && horizontalInput == 0)
        {
            stateMachine.ChangeState(new CharacterIdleState(stateMachine));
        }
    }

    private void Jump(float power)
    {
        stateMachine.characterRigidbody.AddForce(Vector3.up * stateMachine.jumpPower * power, ForceMode.Force);
        stateMachine.currentAmountOfJumps--;
    }
}