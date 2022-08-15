using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Directions playerDirection;
    [Header("Walk Params")]
    public float speedFWD;


    [Header("Jump Params")]
    public float jumpVelocityFWD;
    public float jumpVelocityUPWD;
    public float fallMultiplier;

    [Header("Stairs Params")]
    public float stairsSpeed;

    //cached Components
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public Collider thisCollider;
    [HideInInspector] public CharacterController characterController;
    [HideInInspector] public MyLeanDragTranslateRigidBody leanDragComponent;


    //instance Variables
    [HideInInspector] public Collider trigger;
    [HideInInspector] public Collision collision;


    //states
    public PlayerMotion currentState;
    public PlayerIdle idleState = new PlayerIdle();
    public PlayerJump jumpState = new PlayerJump();
    public PlayerStairs stairsState = new PlayerStairs();
    public PlayerWalk walkState = new PlayerWalk();
    public PlayerWin winState = new PlayerWin();
    public void SetPlayer()
    {
        //caching references
        rb = GetComponent<Rigidbody>();
        thisCollider = GetComponent<Collider>();
        characterController = GetComponent<CharacterController>();
        leanDragComponent = GetComponent<MyLeanDragTranslateRigidBody>();


        SwitchState(idleState);
    }
    public void Update()
    {
        currentState.UpdateState();
    }

    public void OnCollisionEnter(Collision collision)
    {
        this.collision = collision;
        currentState.OnCollisionEnter();
    }
    public void OnTriggerEnter(Collider other)
    {
        this.trigger = other;
        currentState.OnTriggerEnter();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        trigger = hit.collider;
        currentState.OnTriggerEnter();
    }
    public void SwitchState(PlayerMotion state)
    {
        currentState = state;
        currentState.Enter(this);
    }


    #region Events Handlers
    public void OnGameStartedHandler()
    {
        SwitchState(walkState);
    }
    #endregion
}

