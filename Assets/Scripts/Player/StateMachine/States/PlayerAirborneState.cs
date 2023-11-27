using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirborneState: PlayerState
{
    private Rigidbody rb;
    public PlayerAirborneState(PlayerStateMachine stateMachine, PlayerInputActions playerInputActions) : base(stateMachine, playerInputActions) { }

    public override void Construct()
    {
        playerInputActions.Player.Enable();
        rb = stateMachine.rb;
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
        if(stateMachine.GroundedCheck() && rb.velocity.y < 0)
        {
            stateMachine.ChangeState(new PlayerIdleState(stateMachine, playerInputActions));
        }
    }
}
