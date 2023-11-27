using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : PlayerState
{
    private Rigidbody rb;
    private Vector2 inputVector;

    //Constructor
    public PlayerMovingState(PlayerStateMachine stateMachine, PlayerInputActions playerInputActions) : base(stateMachine, playerInputActions) { }

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

        GetInput();
    }

    public override void FixedUpdateState()
    {
        float speed = 10f;
        rb.velocity = new Vector3(inputVector.x, 0, inputVector.y) * speed;
        Debug.Log(rb.velocity);
    }

    public override void CheckTransitions()
    {
        // PlayerIdleState Transition
        if (playerInputActions.Player.Movement.ReadValue<Vector2>() == Vector2.zero)
        {
            rb.velocity = Vector3.zero;
            stateMachine.ChangeState(new PlayerIdleState(stateMachine, playerInputActions));
        }
    }

    private void GetInput()
    {
        inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
    }
}
