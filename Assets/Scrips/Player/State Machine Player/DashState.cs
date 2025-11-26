using UnityEngine;
using UnityEngine.TextCore.Text;
using System.Collections;


public class DashState : BaseState
{
    public DashState(PlayerController controllerParameter) : base(controllerParameter) { }
    public override void EnterState()
    {
        controller.anim.CrossFade("Dash", 0.1f);
        controller.StartDash();

    }
    public override void FixedUpdateState()
    {
        
    }

    public override void UpdateState()
    {
        Debug.Log("Esta en estado Dash");


        if (!controller.inDash && controller.rigid.linearVelocity.y < 0 && !controller.isGrounded)
        {
            ExitState(controller.fall);
        }
        if (!controller.inDash && controller.rigid.linearVelocity.y > 0 && !controller.isGrounded)
        {
            ExitState(controller.jump);
        }

        if (!controller.inDash && controller.isGrounded)
        {
            if (controller.movHori == 0 && controller.movVert == 0)
            {
                ExitState(controller.idle);
            }
            else if (controller.movHori != 0 || controller.movVert != 0)
            { ExitState(controller.run); }
        }
    }

    public override void ExitState(BaseState newState)
    {
        controller.ChangeState(newState);
    }

}
