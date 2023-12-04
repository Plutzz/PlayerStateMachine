using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerState
{
    private Rigidbody rb;
    public PlayerIdleState(PlayerStateMachine stateMachine, PlayerInputActions playerInputActions) : base(stateMachine, playerInputActions) { }

    public override void Construct()
    {
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;

        
        rb = stateMachine.rb;
    }

    public override void Destruct()
    {
        playerInputActions.Player.Disable();
        playerInputActions.Player.Jump.performed -= Jump;
    }

    public override void UpdateState()
    {
        CheckTransitions();
    }
    public override void FixedUpdateState()
    {
        //rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }

    public override void CheckTransitions()
    {
        // PlayerMovingState transition
        if (playerInputActions.Player.Movement.ReadValue<Vector2>() != Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.MovingState);
        }
        if (rb.velocity.y != 0)
        {
            stateMachine.ChangeState(stateMachine.AirborneState);
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        stateMachine.ChangeState(new PlayerAirborneState(stateMachine, playerInputActions));
    }
}
