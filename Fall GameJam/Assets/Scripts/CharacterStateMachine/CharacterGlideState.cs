using Unity.VisualScripting;
using UnityEngine;

public class CharacterGlideState : CharacterBaseState
{
    public CharacterGlideState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        if (!Input.GetKey(stateMachine.jumpKey))
        {
            //change state to idle if horizontal and vertical input is 0 or set to walking/running if it its above zero (check if holding shift for runningd)
        }
    }

    public override void ExitState()
    {
        
    }
}