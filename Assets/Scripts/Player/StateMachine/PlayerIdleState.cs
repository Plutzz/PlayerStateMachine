using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerStateMachine stateMachine, PlayerInputActions playerInputActions) : base(stateMachine, playerInputActions)
    {
    }

    public override void Construct()
    {
        Debug.Log("Construct " + this);

        playerInputActions.Player.Enable();
        
    }

    public override void Destruct()
    {
        Debug.Log("Destruct " + this);
        playerInputActions.Player.Disable();
    }

    public override void UpdateState()
    {
        // if movement input is detected
        // playerMotor.ChangeState
        if (playerInputActions.Player.Movement.ReadValue<Vector2>() != Vector2.zero)
        {
            stateMachine.ChangeState(new PlayerMovingState(stateMachine, playerInputActions));
        }
    }
    public override void FixedUpdateState()
    {

    }
}
