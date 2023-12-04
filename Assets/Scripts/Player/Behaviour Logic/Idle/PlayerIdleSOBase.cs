using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleSOBase : ScriptableObject
{
    protected PlayerStateMachine stateMachine;
    protected Rigidbody rb;
    protected GameObject gameObject;
    protected PlayerInputActions playerInputActions;

    public virtual void Initialize(GameObject gameObject, PlayerStateMachine stateMachine, PlayerInputActions playerInputActions)
    {
        this.gameObject = gameObject;
        rb = gameObject.GetComponent<Rigidbody>();
        this.stateMachine = stateMachine;
        this.playerInputActions = playerInputActions;
    }

    public virtual void DoConstruct() { }
    public virtual void DoDeconstruct() { ResetValues(); }
    public virtual void DoUpdateState() { CheckTransitions(); }
    public virtual void DoPhysicsLogic() { }
    public virtual void ResetValues() { }

    public virtual void CheckTransitions()
    {
        // Idle => Moving
        if (playerInputActions.Player.Movement.ReadValue<Vector2>() != Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.MovingState);
        }
        // Idle => Airborne *** CHANGED TO ELSE IF POSSIBLE BUG
        else if (rb.velocity.y != 0)
        {
            stateMachine.ChangeState(stateMachine.AirborneState);
        }
    }


}
