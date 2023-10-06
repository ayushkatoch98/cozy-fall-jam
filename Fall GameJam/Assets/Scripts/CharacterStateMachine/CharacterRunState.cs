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
        stateMachine.HandleMoving(stateMachine.walkSpeed);

        if (stateMachine.verticalInput <= 0 || stateMachine.horizontalInput <= 0)
        {
            stateMachine.ChangeState(new CharacterIdleState(stateMachine));
        }
    }

    public override void ExitState()
    {
        
    }
}