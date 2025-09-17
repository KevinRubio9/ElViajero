using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class JumpState : BaseState
{
    public JumpState (PlayerController controllerParameter) : base(controllerParameter) { }
    public override void EnterState()
    {
        Debug.Log("Entro en estado salto");
        if (Input.GetButtonDown("Jump") && controller.isGrounded && !controller.poisoned)
        {
            controller.velocity.y = Mathf.Sqrt(controller.forceJump * -2 * controller.gravity);
        }
        else if (Input.GetButtonDown("Jump") && controller.isGrounded && controller.poisoned)
        {
            controller.velocity.y = Mathf.Sqrt(controller.forceJumpCorrupted * -2 * controller.gravity);
        }
    }

    public override void UpdateState()
    {


    }

    public override void ExitState(BaseState newState)
    {

    }
}
