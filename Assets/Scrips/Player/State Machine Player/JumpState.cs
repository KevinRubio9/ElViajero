using Unity.Android.Gradle.Manifest;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class JumpState : BaseState
{
    public JumpState(PlayerController controllerParameter) : base(controllerParameter) { }
    public override void EnterState()
    {
        if (controller.isGrounded)
        {
            controller.anim.CrossFade("Jump", 0.1f);

            if (!controller.poisoned)
            {
                controller.velocity.y = Mathf.Sqrt(controller.forceJump * -2 * controller.gravity);
            }
            else if (controller.poisoned)
            {
                controller.velocity.y = Mathf.Sqrt(controller.forceJumpCorrupted * -2 * controller.gravity);
            }
        }
        else
        {
            controller.anim.CrossFade("JumpIdle", 0.1f);
        }
    }

    public override void UpdateState()
    {
        Debug.Log("Esta en estado salto");

        Vector3 mov = new Vector3(controller.movHori, 0, controller.movVert);

        float camDirection = controller.cam.eulerAngles.y;
        Vector3 movByCam = Quaternion.Euler(0f, camDirection, 0f) * mov;
        if (!controller.poisoned)
        {
            controller.character.Move(movByCam * controller.speed * Time.deltaTime);

        }
        else { controller.character.Move(movByCam * controller.speedCorrupted * Time.deltaTime); }
        if (mov != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movByCam);
            controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, targetRotation, controller.sdRotate * Time.deltaTime);
        }

        if (Input.GetButtonDown("Fire3") && controller.canDash)
        {
            ExitState(controller.dash);
        }

        if (controller.velocity.y < 0 && !controller.isGrounded)
        {
            ExitState(controller.fall);
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
