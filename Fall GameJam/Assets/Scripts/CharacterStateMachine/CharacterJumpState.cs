using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterJumpState : CharacterBaseState
{
    public CharacterJumpState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void EnterState()
    {
        stateMachine.amountOfJumps--;
        Jump();
    }

    public override void UpdateState()
    {
        stateMachine.HandleMoving(stateMachine.walkSpeed);

        if (stateMachine.IsGrounded())
        {
            if (stateMachine.horizontalInput >= 0 || stateMachine.verticalInput >= 0)
            {
                stateMachine.ChangeState(new CharacterWalkState(stateMachine));
            }
            else if ((stateMachine.horizontalInput >= 0 || stateMachine.verticalInput >= 0) && Input.GetKey(stateMachine.sprintKey))
            {
                stateMachine.ChangeState(new CharacterWalkState(stateMachine));
            }
        }
        else if (!stateMachine.IsGrounded())
        {
            if (stateMachine.amountOfJumps > 0 && Input.GetKeyDown(stateMachine.jumpKey))
            {
                stateMachine.amountOfJumps--;
                Jump();
            }
            else if (stateMachine.amountOfJumps == 0 && Input.GetKey(stateMachine.jumpKey))
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
    }
}