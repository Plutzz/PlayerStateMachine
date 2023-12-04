using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirborneSOBase : ScriptableObject
{
    protected PlayerStateMachine stateMachine;
    protected Rigidbody rb;
    protected GameObject gameObject;
    protected PlayerInputActions playerInputActions;
    protected Vector2 inputVector;

    public virtual void Initialize(GameObject gameObject, PlayerStateMachine stateMachine, PlayerInputActions playerInputActions)
    {
        this.gameObject = gameObject;
        this.stateMachine = stateMachine;
        rb = stateMachine.rb;
        this.playerInputActions = playerInputActions;
    }

    public virtual void DoEnterLogic() { }
    public virtual void DoExitLogic() { ResetValues(); }
    public virtual void DoUpdateState() { CheckTransitions(); }
    public virtual void DoFixedUpdateState() { }
    public virtual void ResetValues() { }

    public virtual void CheckTransitions()
    {
        //Airborne => Moving
        if (stateMachine.GroundedCheck() && playerInputActions.Player.Jump.ReadValue<float>() == 0)
        {
            stateMachine.ChangeState(stateMachine.MovingState);
        }
    }
}
