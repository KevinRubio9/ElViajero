using UnityEngine;

public class DeadStateCogollo : BaseStateCogollo
{

    public DeadStateCogollo(EnemyShooterLogic controllerParameter) : base(controllerParameter) { }

    public override void EnterState()
    {
    }
    public override void UpdateState()
    {

    }
    public override void ExitState(BaseStateCogollo newState)
    {
        controller.ChangeState(newState);
    }

}
