using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private PlayerState currentState;
    private PlayerState initialState = new PlayerIdleState();
    public PlayerInputActions playerInputActions {  get; private set; }


    //[Header("Player Attributes")]
    public Rigidbody rb { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInputActions();
    }
    private void Start()
    {
        currentState = initialState;
        currentState.Construct(this);
    }

    private void Update()
    {
        currentState.UpdateState();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState();
    }

    public void ChangeState(PlayerState newState)
    {
        currentState.Destruct();
        currentState = newState;
        currentState.Construct(this);
    }
}
