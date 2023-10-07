using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterIdleState : CharacterBaseState
{
    public CharacterIdleState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (verticalInput != 0 || horizontalInput != 0)
        {
            stateMachine.ChangeState(new CharacterWalkState(stateMachine));
        }
        else if (verticalInput != 0 || horizontalInput != 0 && Input.GetKey(stateMachine.sprintKey))
        {
            stateMachine.ChangeState(new CharacterRunState(stateMachine));
        }

        if (Input.GetKeyDown(stateMachine.jumpKey))
        {
            stateMachine.ChangeState(new CharacterJumpState(stateMachine));
        }
    }

    public override void ExitState()
    {
        
    }
}