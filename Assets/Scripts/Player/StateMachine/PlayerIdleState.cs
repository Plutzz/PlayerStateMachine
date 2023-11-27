using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    protected Rigidbody rb;
    public override void Construct(PlayerMotor currentMotor)
    {
        Debug.Log("Construct " + this);
        motor = currentMotor;

        rb = motor.rb;
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
        // if movement input is detected
        // playerMotor.ChangeState
        if (playerInputActions.Player.Movement.ReadValue<Vector2>() != Vector2.zero)
        {
            motor.ChangeState(new PlayerMovingState());
        }
    }
    public override void FixedUpdateState()
    {

    }
}
