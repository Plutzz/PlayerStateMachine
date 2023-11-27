using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : PlayerState
{
    public PlayerMovingState(PlayerStateMachine stateMachine, PlayerInputActions playerInputActions) : base(stateMachine, playerInputActions) { }

    public override void Construct()
    {
        playerInputActions.Player.Enable();
    }

    public override void Destruct()
    {
        playerInputActions.Player.Disable();
    }

    public override void UpdateState()
    {
        CheckTransitions();
    }

    public override void FixedUpdateState()
    {

    }

    public override void CheckTransitions()
    {
        // PlayerIdleState Transition
        if (playerInputActions.Player.Movement.ReadValue<Vector2>() == Vector2.zero)
        {
            stateMachine.ChangeState(new PlayerIdleState(stateMachine, playerInputActions));
        }
    }
}
