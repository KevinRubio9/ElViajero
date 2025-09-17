using UnityEngine;

public class RunState : BaseState
{
    public RunState(PlayerController controllerParameter) :base (controllerParameter) { }

    public override void EnterState()
    {
        Debug.Log("Entro en estado Run");

    }

    public override void UpdateState()
    {

    }

    public override void ExitState(BaseState newState)
    {

    }
}
