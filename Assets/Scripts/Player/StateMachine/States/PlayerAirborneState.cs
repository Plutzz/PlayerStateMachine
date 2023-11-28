using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirborneState: PlayerState
{
    private Rigidbody rb;
    private Vector2 inputVector;
    public PlayerAirborneState(PlayerStateMachine stateMachine, PlayerInputActions playerInputActions) : base(stateMachine, playerInputActions) { }

    public override void Construct()
    {
        playerInputActions.Player.Enable();
        rb = stateMachine.rb;
    }

    public override void Destruct()
    {
        playerInputActions.Player.Disable();
        rb.velocity = Vector3.zero;
    }
    public override void UpdateState()
    {
        CheckTransitions();
        GetInput();
        Move();
    }

    public override void FixedUpdateState()
    {

    }

    public override void CheckTransitions()
    {
        if(stateMachine.GroundedCheck() && playerInputActions.Player.Jump.ReadValue<float>() == 0)
        {
            stateMachine.ChangeState(new PlayerIdleState(stateMachine, playerInputActions));
        }
    }

    private void Move()
    {
        //Debug.Log(inputVector);
        float speed = 10f;
        rb.velocity = new Vector3(inputVector.x * speed, rb.velocity.y, inputVector.y * speed);
        //Debug.Log(rb.velocity);
    }
    private void GetInput()
    {
        inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
    }
}
