using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirborneState: PlayerState
{
    public PlayerAirborneState(PlayerStateMachine stateMachine, PlayerInputActions playerInputActions) : base(stateMachine, playerInputActions) { }

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
        
    }
}
