using System.Collections;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
public class CharacterRunState : CharacterBaseState
{
    public CharacterRunState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void EnterState()
    {
        //stateMachine.StopAllCoroutines();
        //stateMachine.StartCoroutine(stateMachine.ChangeFOV(Camera.main.fieldOfView, 90));
        stateMachine.runParticleSystem.Play();
    }

    public override void UpdateState()
    {
        stateMachine.HandleMoving(stateMachine.runSpeed);

        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        if (!stateMachine.isGrounded && stateMachine.runParticleSystem.isPlaying)
        {
            stateMachine.runParticleSystem.Stop();
        }
        else if (stateMachine.isGrounded && !stateMachine.runParticleSystem.isPlaying)
        {
            stateMachine.runParticleSystem.Play();
        }

        if (Input.GetKeyDown(stateMachine.jumpKey) && stateMachine.isGrounded)
        {
            stateMachine.ChangeState(new CharacterJumpState(stateMachine));
        }

        if (verticalInput == 0 && horizontalInput == 0)
        {
            stateMachine.ChangeState(new CharacterIdleState(stateMachine));
        }

        if (!Input.GetKey(stateMachine.sprintKey) && (verticalInput != 0 || horizontalInput != 0))
        {
            stateMachine.ChangeState(new CharacterWalkState(stateMachine));
        }

    }

    public override void ExitState()
    {
        //stateMachine.StopAllCoroutines();
        //stateMachine.StartCoroutine(stateMachine.ChangeFOV(Camera.main.fieldOfView, 70));
        stateMachine.runParticleSystem.Stop();
    }
}