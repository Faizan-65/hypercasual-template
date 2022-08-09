public abstract class PlayerState
{
    public abstract void Enter(PlayerController controller);
    public abstract void OnTriggerEnter();
    public abstract void OnCollisionEnter();
    public abstract void UpdateState();
    public abstract void Exit();
}
