using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class CharacterRunState : CharacterBaseState
{
    public CharacterRunState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    private float fovTransitionSpeed = 0.5f;

    public override void EnterState()
    {
        //StartCoroutine(ChangeFOV(Camera.main.fieldOfView, 90));
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

        if (verticalInput != 0 && horizontalInput != 0 && !Input.GetKey(stateMachine.sprintKey))
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
        //ChangeFOV(Camera.main.fieldOfView, 70);
    }
}