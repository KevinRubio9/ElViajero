using UnityEngine;

public class IdleState : BaseState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public IdleState(PlayerController controllerParameter) : base(controllerParameter) { }

    public override void EnterState()
    {
        Debug.Log("Entro en estado Idle");
    }

    public override void UpdateState()
    {

    }

    public override void ExitState(BaseState newState)
    {

    }
}
