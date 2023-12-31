using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Moving-Momentum", menuName = "Player Logic/Moving Logic/Momentum")]
public class PlayerMovingMomentum : PlayerMovingSOBase
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float groundDrag = 1f;
    private Transform cam;

    private float turnSmoothVelocity;
    public override void Initialize(GameObject gameObject, PlayerStateMachine stateMachine, PlayerInputActions playerInputActions)
    {
        base.Initialize(gameObject, stateMachine, playerInputActions);
        cam = Camera.main.transform;
    }
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        playerInputActions.Player.Jump.performed += Jump;
        Cursor.lockState = CursorLockMode.Locked;
        rb.drag = groundDrag;
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        playerInputActions.Player.Jump.performed -= Jump;
    }

    public override void DoFixedUpdateState()
    {
        Move();
        base.DoFixedUpdateState();
    }

    public override void DoUpdateState()
    {
        GetInput();
        base.DoUpdateState();
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
        float targetAngle = Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(gameObject.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        gameObject.transform.rotation = Quaternion.Euler(0f, angle, 0f);
        float speed = this.speed;

        if (playerInputActions.Player.Sprint.ReadValue<float>() == 1)
        {
            speed = speed * 2;
        }

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        rb.AddForce(moveDir.normalized * speed, ForceMode.Force);
    }
}
