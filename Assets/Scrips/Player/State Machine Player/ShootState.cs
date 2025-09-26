using UnityEngine;

public class ShootState : BaseState
{
    public ShootState (PlayerController controllerParameter) : base(controllerParameter) { }
    public override void EnterState()
    {
        Debug.Log("Entro en estado Shoot");
    }

    public override void UpdateState()
    {

    }

    public override void ExitState(BaseState newState)
    {
        controller.ChangeState(newState);

    }
}
