using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class CharacterRunState : CharacterBaseState
{
    public CharacterRunState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void EnterState()
    {
        stateMachine.StartCoroutine(stateMachine.ChangeFOV(Camera.main.fieldOfView, 90));
    }

    public override void UpdateState()
    {
        stateMachine.HandleMoving(stateMachine.runSpeed);
        
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(stateMachine.jumpKey) && stateMachine.isGrounded)
        {
            stateMachine.ChangeState(new CharacterJumpState(stateMachine));
        }

        if (!Input.GetKey(stateMachine.sprintKey) && verticalInput != 0 && horizontalInput != 0)
        {
            stateMachine.ChangeState(new CharacterWalkState(stateMachine));
        }

        if (verticalInput == 0 && horizontalInput == 0)
        {
            stateMachine.ChangeState(new CharacterIdleState(stateMachine));
        }
    }

    public override void ExitState()
    {
        stateMachine.StartCoroutine(stateMachine.ChangeFOV(Camera.main.fieldOfView, 70));
    }
}