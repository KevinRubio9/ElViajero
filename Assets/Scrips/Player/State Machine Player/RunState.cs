using System;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class RunState : BaseState
{
    public RunState(PlayerController controllerParameter) :base (controllerParameter) { }

    public override void EnterState()
    {
        controller.anim.CrossFade("Run",0.1f,0);
    }
    public override void FixedUpdateState()
    {
        controller.Movement();
    }

    public override void UpdateState()
    {
        Debug.Log("Esta en estado Run");


        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            ExitState(controller.jump);
        }

        if (Input.GetButtonDown("Fire3") && controller.canDash)
        {
            ExitState(controller.dash);
        }

        if (controller.movHori == 0 && controller.movVert == 0)
        {
            ExitState(controller.idle);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            ExitState(controller.shoot);
        }
    }

    public override void ExitState(BaseState newState)
    {
        controller.ChangeState(newState);

    }

}
