using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState
{
    // Fields to be assigned during the Construct() methods
    protected PlayerStateMachine stateMachine;
    protected PlayerInputActions playerInputActions;

    /// <summary>
    /// Constructor used to pass references of the stateMachine and playerInputActions
    /// to the next state.
    /// </summary>
    /// <param name="stateMachine"></param>
    /// <param name="playerInputActions"></param>
    public PlayerState(PlayerStateMachine stateMachine, PlayerInputActions playerInputActions)
    {
        this.stateMachine = stateMachine;
        this.playerInputActions = playerInputActions;
    }


    /// <summary>
    /// Setup state, e.g. starting animations.
    /// Consider this the "Start" method of this state.
    /// </summary>
    public virtual void Construct()
    {

    }

    /// <summary>
    /// State-Cleanup.
    /// </summary>
    public virtual void Destruct()
    {

    }

    /// <summary>
    /// This method is called once every frame while this state is active.
    /// Consider this the "Update" method of this state.
    /// </summary>
    public virtual void UpdateState()
    { 
    
    }

    /// <summary>
    /// This method is called once every physics frame while this state is active.
    /// Consider this the "FixedUpdate" method of this state.
    /// </summary>
    public virtual void FixedUpdateState()
    {

    }
    /// <summary>
    /// This method contains checks for all transitions from the current state.
    /// To be called in the UpdateState() or FixedUpdateState() methods.
    /// </summary>
    public virtual void CheckTransitions()
    {

    }
}

