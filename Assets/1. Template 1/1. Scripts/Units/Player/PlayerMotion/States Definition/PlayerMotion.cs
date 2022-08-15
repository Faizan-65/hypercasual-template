using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMotion
{
    public abstract void Enter(PlayerController controller);
    public abstract void OnTriggerEnter();
    public abstract void OnCollisionEnter();
    public abstract void UpdateState();
    public abstract void Exit(PlayerMotion state);
}
