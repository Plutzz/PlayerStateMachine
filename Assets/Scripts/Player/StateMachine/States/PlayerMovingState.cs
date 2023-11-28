using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovingState : PlayerState
{
    private Rigidbody rb;
    private Vector2 inputVector;

    //Constructor
    public PlayerMovingState(PlayerStateMachine stateMachine, PlayerInputActions playerInputActions) : base(stateMachine, playerInputActions) { }

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
        GetInput();
        Move();
        
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

    //Helper Methods
    private void GetInput()
    {
        inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
    }

    private void Move()
    {
        Debug.Log(inputVector);
        float speed = 10f;
        rb.velocity = new Vector3(inputVector.x * speed, rb.velocity.y, inputVector.y * speed);
        //Debug.Log(rb.velocity);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        //Debug.Log(context);
        //Debug.Log("Jump!" + context.phase);
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        stateMachine.ChangeState(new PlayerAirborneState(stateMachine, playerInputActions));
    }
}
