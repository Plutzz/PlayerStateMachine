using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private PlayerState currentState;
    public PlayerInputActions playerInputActions { get; private set; }
    private PlayerState initialState;
    public Rigidbody rb { get; private set; }


    #region Debug Variables
    public TextMeshProUGUI CurrentStateText;
    #endregion

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        initialState = new PlayerIdleState(this, playerInputActions);

    }
    private void Start()
    {
        currentState = initialState;
        currentState.Construct();
    }

    private void Update()
    {
        currentState.UpdateState();
        CurrentStateText.text = "Current State: " + currentState.ToString();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState();
    }

    public void ChangeState(PlayerState newState)
    {
        currentState.Destruct();
        currentState = newState;
        currentState.Construct();
    }

    //Consider adding core functionalities here
    // Ex: GroundedCheck
}
