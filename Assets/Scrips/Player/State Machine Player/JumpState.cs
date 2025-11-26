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
                controller.rigid.AddForce(Vector3.up * controller.forceJump, ForceMode.Impulse);
            }
            else if (controller.poisoned)
            {
                controller.rigid.AddForce(Vector3.up * controller.forceJumpCorrupted, ForceMode.Impulse);
            }
        }
        else
        {
            controller.anim.CrossFade("JumpIdle", 0.1f);
        }
    }
    public override void FixedUpdateState()
    {
        controller.Movement();
    }

    public override void UpdateState()
    {
        Debug.Log("Esta en estado salto");


        if (Input.GetButtonDown("Fire3") && controller.canDash)
        {
            ExitState(controller.dash);
        }

        if (controller.rigid.linearVelocity.y < 0)
        {
            ExitState(controller.fall);
        }


        if (Input.GetButtonDown("Fire1"))
        {
            controller.ShootBullet();
            ExitState(controller.shoot);
        }

    }

    public override void ExitState(BaseState newState)
    {
        controller.ChangeState(newState);

    }
}
