using UnityEngine;

public class DeadStatePlayer : BaseState
{
    public DeadStatePlayer(PlayerController controllerParameter) : base(controllerParameter) { }

    public override void EnterState()
    {
        Debug.Log("nos morimos perro");
        controller.anim.CrossFade("Dead", 0.1f);
    }
    public override void FixedUpdateState()
    {

    }

    public override void UpdateState()
    {
        Debug.Log("Player esta en estado Dead");

    }

    public override void ExitState(BaseState newState)
    {
        controller.ChangeState(newState);
    }
}
