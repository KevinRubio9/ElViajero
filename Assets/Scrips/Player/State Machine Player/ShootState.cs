using UnityEngine;

public class ShootState : BaseState
{
    public ShootState (PlayerController controllerParameter) : base(controllerParameter) { }
    public override void EnterState()
    {
        Debug.Log("Entro en estado Shoot");
        controller.anim.Play("Shoot");
    }

    public override void UpdateState()
    {
        if (controller.isGrounded && controller.movHori == 0 && controller.movVert == 0)
        {
            ExitState(controller.idle);
        }
        else { ExitState(controller.run); }
    }

    public override void ExitState(BaseState newState)
    {
        controller.ChangeState(newState);

    }

    public override void AnimationEvent()
    {

    }
}
