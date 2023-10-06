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
        stateMachine.HandleMoving(stateMachine.runSpeed);

        if (!Input.GetKey(stateMachine.sprintKey) && stateMachine.characterRigidbody.velocity.magnitude > 0)
        {
            stateMachine.ChangeState(new CharacterWalkState(stateMachine));
        }

        if (Input.GetKeyDown(stateMachine.jumpKey))
        {
            stateMachine.ChangeState(new CharacterJumpState(stateMachine));
        }

        if (stateMachine.characterRigidbody.velocity.magnitude <= 0.01f)
        {
            stateMachine.ChangeState(new CharacterIdleState(stateMachine));
        }
    }

    public override void ExitState()
    {
        
    }
}