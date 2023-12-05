using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Airborne-FullControl", menuName = "Player Logic/Airborne Logic/Full Control")]
public class PlayerAirborneFullControl : PlayerAirborneSOBase
{
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFixedUpdateState()
    {
        base.DoFixedUpdateState();
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();
        GetInput();
        Move();
    }

    public override void ResetValues()
    {
        base.ResetValues();
        rb.velocity = Vector3.zero;
    }

    private void GetInput()
    {
        inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
    }
    private void Move()
    {
        float speed = 10f;
        rb.velocity = new Vector3(inputVector.x * speed, rb.velocity.y, inputVector.y * speed);
    }
}
