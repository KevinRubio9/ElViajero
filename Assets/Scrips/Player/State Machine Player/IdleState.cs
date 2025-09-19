using UnityEngine;

public class IdleState : BaseState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public IdleState(PlayerController controllerParameter) : base(controllerParameter) { }

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {
        Debug.Log("Esta en estado Idle");

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            ExitState(controller.jump);
        }

        if (controller.movHori != 0  || controller.movVert != 0)
        {
            ExitState(controller.run);
        }
    }

    public override void ExitState(BaseState newState)
    {
        controller.ChangeState(newState);
    }
}
