using UnityEngine;
using UnityEngine.TextCore.Text;
using System.Collections;


public class DashState : BaseState
{
    public DashState(PlayerController controllerParameter) : base(controllerParameter) { }
    public override void EnterState()
    {
        Debug.Log("Entro en estado Dash");
        controller.StartDash();

    }

    public override void UpdateState()
    {

    }

    public override void ExitState(BaseState newState)
    {

    }
}
