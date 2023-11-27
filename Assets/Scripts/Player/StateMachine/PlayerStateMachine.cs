using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private PlayerState currentState;
    private PlayerState initialState;
    public PlayerInputActions playerInputActions { get; private set; }


    public Rigidbody rb { get; private set; }
    public Transform GroundCheck;
    public Vector3 GroundCheckSize;
    [SerializeField] LayerMask groundLayer;


    #region Debug Variables
    public TextMeshProUGUI CurrentStateText;
    #endregion

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        initialState = new PlayerIdleState(this, playerInputActions);
        rb = GetComponent<Rigidbody>();

    }
    private void Start()
    {
        currentState = initialState;
        currentState.Construct();
    }

    private void Update()
    {
        Debug.Log(GroundedCheck());
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
    public bool GroundedCheck()
    {
        return Physics.OverlapBox(GroundCheck.position, GroundCheckSize, Quaternion.identity, groundLayer).Length > 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(GroundCheck.position, new Vector3(GroundCheckSize.x, GroundCheckSize.y, GroundCheckSize.z));
    }
}
