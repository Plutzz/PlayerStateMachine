using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Moving-NoMomentum", menuName = "Player Logic/Moving Logic/NoMomentum")]
public class PlayerMovingNoMomentum : PlayerMovingSOBase
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private CinemachineFreeLook freeLookCamera;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        playerInputActions.Player.Disable();
        playerInputActions.Player.Jump.performed -= Jump;
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
    }

    //Helper Methods
    private void GetInput()
    {
        inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
    }
    private void Jump(InputAction.CallbackContext context)
    {
        //Debug.Log(context);
        //Debug.Log("Jump!" + context.phase);
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

    private void Move()
    {
        float targetAngle = Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        rb.velocity = new Vector3(inputVector.x * speed, rb.velocity.y, inputVector.y * speed);
        //Debug.Log(rb.velocity);
    }
}
