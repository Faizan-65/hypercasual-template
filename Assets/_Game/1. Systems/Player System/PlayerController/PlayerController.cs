using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Events")]
    public GameEvent levelCompleted;

    [Header("References")]
    public Rigidbody rb;
    public Collider col;
    public SwerveInput swerve;
    public Animator playerAnimator;
    
    public PlayerState currentState;
    public PlayerIdleState idleState=new PlayerIdleState();
    public PlayerWalkState walkState=new PlayerWalkState();
    public PlayerWinState winState = new PlayerWinState();
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void SwitchState(PlayerState state)
    {
        currentState = state;
        currentState.Enter(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(collision);
    }
    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
        if (other.CompareTag(StringsHolder.end))
        {
            ReferenceHolder.speedForward = 0;
            levelCompleted.Raise();
            currentState.Exit(winState);
        }
    }


    #region Handlers

    public void PlayerSpawnedHandler()
    {
        playerAnimator = ReferenceHolder.playerModelAnimator;
        SwitchState(idleState);
    }

    public void PlayButtonClickedHandler()
    {
        currentState.Exit(walkState);
    }
    #endregion
}
