using Unity.Android.Gradle.Manifest;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class JumpState : BaseState
{
    public JumpState(PlayerController controllerParameter) : base(controllerParameter) { }
    public override void EnterState()
    {
        if (!controller.poisoned)
        {
            controller.velocity.y = Mathf.Sqrt(controller.forceJump * -2 * controller.gravity);
        }
        else if (controller.poisoned)
        {
            controller.velocity.y = Mathf.Sqrt(controller.forceJumpCorrupted * -2 * controller.gravity);
        }
    }

    public override void UpdateState()
    {
        Debug.Log("Esta en estado salto");
   

        if (Input.GetButtonDown("Fire3") && controller.canDash)
        {
            ExitState(controller.dash);
        }

        if (controller.velocity.y < 0 && !controller.isGrounded)
        {
            Debug.Log("Esta cayendo metanle anim de caer, gracias");
        }

        if (controller.isGrounded && controller.VelocityY < 0)
        {
            Debug.Log("WHAAt");
            if (controller.movHori == 0 && controller.movVert == 0)
            {
                ExitState(controller.idle);
            }
            else { ExitState(controller.run); }
        }

    }

    public override void ExitState(BaseState newState)
    {
        controller.ChangeState(newState);

    }
}
