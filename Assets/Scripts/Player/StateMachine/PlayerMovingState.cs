using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : PlayerState
{
    public override void Construct(PlayerMotor currentMotor)
    {
        Debug.Log("Construct " + this);
        motor = currentMotor;

        playerInputActions = motor.playerInputActions;
        playerInputActions.Player.Enable();
    }

    public override void Destruct()
    {
        Debug.Log("Destruct " + this);
        playerInputActions.Player.Disable();
    }

    public override void UpdateState()
    {
        if (playerInputActions.Player.Movement.ReadValue<Vector2>() == Vector2.zero)
        {
            motor.ChangeState(new PlayerIdleState());
        }
    }

    public override void FixedUpdateState()
    {

    }
}
