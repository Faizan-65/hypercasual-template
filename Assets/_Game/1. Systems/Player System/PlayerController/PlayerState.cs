using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public abstract void Enter(PlayerController controller);
    public abstract void UpdateState();
    public abstract void Exit(PlayerState state);
    public abstract void OnCollisionEnter(Collision collision);
    public abstract void OnTriggerEnter(Collider other);
}
