using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachines.Player;

public class PlayerMotor : MonoBehaviour
{
    private BaseState currentState;
    private BaseState initialState = new PlayerIdleState();

    private void Start()
    {
        currentState = initialState;
        currentState.Construct();
    }

    private void Update()
    {
        currentState.UpdateState();
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Destruct();
        currentState = newState;
        currentState.Construct();
    }
}
