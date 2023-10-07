using System.Data;
using UnityEngine;
public class CharacterWalkState : CharacterBaseState
{
    public CharacterWalkState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {
        stateMachine.HandleMoving(stateMachine.walkSpeed);
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(stateMachine.jumpKey) && stateMachine.isGrounded)
        {
            stateMachine.ChangeState(new CharacterJumpState(stateMachine));
        }

        if (Input.GetKey(stateMachine.sprintKey))
        {
            stateMachine.ChangeState(new CharacterRunState(stateMachine));
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