using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class FallState : BaseState
{

    public FallState(PlayerController controllerParameter) : base(controllerParameter) { }

    public override void EnterState()
    {
        controller.anim.CrossFade("Fall",0.1f);
    }
    public override void FixedUpdateState()
    {
      
    }

    public override void UpdateState()
    {
        Debug.Log("Esta en estado Fall");



        if (controller.isGrounded && controller.rigid.linearVelocity.y < 0)
        {
            if (controller.movHori == 0 && controller.movVert == 0)
            {
                ExitState(controller.idle);
            }
            else { ExitState(controller.run); }
        }
        if (Input.GetButtonDown("Fire3") && controller.canDash)
        {
            ExitState(controller.dash);
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
