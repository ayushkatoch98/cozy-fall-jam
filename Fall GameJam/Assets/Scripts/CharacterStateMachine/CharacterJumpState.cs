using System.Data;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterJumpState : CharacterBaseState
{
    public CharacterJumpState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void EnterState()
    {
        Jump();
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

        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (stateMachine.isGrounded)
        {
            if (stateMachine.hardLanding)
            {
                Debug.Log("hard landing!");
                stateMachine.hardLanding = false;
                stateMachine.landingParticleSystem.Play();
            }
            stateMachine.currentAmountOfJumps = stateMachine.amountOfJumps;

            if (verticalInput != 0 || horizontalInput != 0)
            {
                stateMachine.ChangeState(new CharacterWalkState(stateMachine));
            }
            else if ((verticalInput != 0 || horizontalInput != 0) && Input.GetKey(stateMachine.sprintKey))
            {
                stateMachine.ChangeState(new CharacterRunState(stateMachine));
            }

            if (verticalInput == 0 && horizontalInput == 0)
            {
                stateMachine.ChangeState(new CharacterIdleState(stateMachine));
            }
        }
        else if (!stateMachine.isGrounded)
        {
            if (stateMachine.currentAmountOfJumps > 0 && Input.GetKeyDown(stateMachine.jumpKey))
            {
                Jump();
                stateMachine.hardLanding = true;
            }
            else if (stateMachine.currentAmountOfJumps == 0 && Input.GetKey(stateMachine.jumpKey))
            {
                //stateMachine.ChangeState(new )
            }
        }
    }

    public override void ExitState()
    {
        
    }

    private void Jump()
    {
        stateMachine.characterRigidbody.AddForce(Vector3.up * stateMachine.jumpPower, ForceMode.Impulse);

        stateMachine.currentAmountOfJumps--;
    }
}