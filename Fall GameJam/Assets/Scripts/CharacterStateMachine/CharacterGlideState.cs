using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class CharacterGlideState : CharacterBaseState
{
    public CharacterGlideState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    private float tempYPos;
    private float tempGrav;

    public override void EnterState()
    {
        tempYPos = stateMachine.transform.position.y;
        tempGrav = stateMachine.gameObject.GetComponent<CustomGravity>().gravityStrength;

        stateMachine.gameObject.GetComponent<CustomGravity>().gravityStrength = 1;
    }

    public override void UpdateState()
    {
        stateMachine.HandleMoving(stateMachine.glideSpeed);

        stateMachine.transform.position = new Vector3(stateMachine.transform.position.x, Mathf.Clamp(stateMachine.transform.position.y, Mathf.NegativeInfinity, tempYPos), stateMachine.transform.position.z);

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (!Input.GetKey(stateMachine.jumpKey) || stateMachine.currentGlideDuration >= stateMachine.maxGlideDuration)
        {
            stateMachine.currentGlideDuration = 0;

            if (verticalInput == 0 && horizontalInput == 0)
            {
                stateMachine.ChangeState(new CharacterIdleState(stateMachine));
            }

            if (Input.GetKey(stateMachine.sprintKey) && (verticalInput != 0 || horizontalInput != 0))
            {
                stateMachine.ChangeState(new CharacterWalkState(stateMachine));
            }

            if (verticalInput != 0 || horizontalInput != 0)
            {
                stateMachine.ChangeState(new CharacterWalkState(stateMachine));
            }
        }

        stateMachine.currentGlideDuration += Time.deltaTime;
    }

    public override void ExitState()
    {
        stateMachine.gameObject.GetComponent<CustomGravity>().gravityStrength = tempGrav;
    }
}