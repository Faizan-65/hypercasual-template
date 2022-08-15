using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMonetaryBase
{
    public abstract void Enter(PlayerMonetaryController controller);
    public abstract void OnTriggerEnter();
    public abstract void OnCollisionEnter();
    public abstract void UpdateState();
    public abstract void Exit(PlayerMonetaryBase state);
}
