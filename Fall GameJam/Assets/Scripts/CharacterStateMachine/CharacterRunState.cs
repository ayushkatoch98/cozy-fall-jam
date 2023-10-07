using System.Data;
using UnityEngine;
public class CharacterRunState : CharacterBaseState
{
    public CharacterRunState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        stateMachine.HandleMoving(stateMachine.runSpeed, 40);
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (verticalInput != 0 && horizontalInput != 0 && !Input.GetKey(stateMachine.sprintKey))
        {
            stateMachine.ChangeState(new CharacterWalkState(stateMachine));
        }

        if (Input.GetKeyDown(stateMachine.jumpKey) && stateMachine.isGrounded)
        {
            stateMachine.ChangeState(new CharacterJumpState(stateMachine));
        }

        if (verticalInput == 0 && horizontalInput == 0)
        {
            stateMachine.ChangeState(new CharacterIdleState(stateMachine));
        }
    }

    public override void ExitState()
    {
        
    }
}