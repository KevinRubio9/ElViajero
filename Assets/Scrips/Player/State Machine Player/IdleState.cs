using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(PlayerController controllerParameter) : base(controllerParameter) { }

    public override void EnterState()
    {
        controller.anim.CrossFade("Idle",0.1f,0);
    }

    public override void UpdateState()
    {
        Debug.Log("Esta en estado Idle");

        if (Input.GetButtonDown("Fire3") && controller.canDash)
        {
            ExitState(controller.dash);
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            ExitState(controller.jump);
        }

        if (controller.movHori != 0  || controller.movVert != 0)
        {
            ExitState(controller.run);
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

    public override void FixedUpdateState()
    {
        
    }
}
