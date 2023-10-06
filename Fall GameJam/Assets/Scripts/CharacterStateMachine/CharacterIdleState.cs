using Unity.VisualScripting;
using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public CharacterIdleState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        if (stateMachine.horizontalInput >= 0 || stateMachine.verticalInput >= 0)
        {
            stateMachine.ChangeState(new CharacterWalkState(stateMachine));
        }
        else if ((stateMachine.horizontalInput >= 0 || stateMachine.verticalInput >= 0) && Input.GetKey(stateMachine.sprintKey))
        {
            stateMachine.ChangeState(new CharacterRunState(stateMachine));
        }
    }

    public override void ExitState()
    {
        
    }
}