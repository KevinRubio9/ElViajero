using NUnit.Framework.Constraints;
using UnityEngine;

public class ShootState : BaseState
{
    public ShootState(PlayerController controllerParameter) : base(controllerParameter) { }
    float time;
    public override void EnterState()
    {
        Debug.Log("Entro en estado Shoot");
        controller.anim.CrossFade("Shoot", 0.1f, 1);
    }

    public override void UpdateState()
    {
        time += Time.deltaTime;
        if (time > 0.5F)
        {
            ExitState(controller.idle);
            time = 0;
        }

        /*    if (controller.isGrounded && controller.movHori == 0 && controller.movVert == 0)
            {
                ExitState(controller.idle);
            }
            else { ExitState(controller.run); }*/
    }

    public override void ExitState(BaseState newState)
    {
        controller.ChangeState(newState);

    }

    public override void AnimationEvent()
    {

    }

    public override void FixedUpdateState()
    {
        Vector3 mov = new Vector3(controller.movHori, 0, controller.movVert);

        float camDirection = controller.cam.eulerAngles.y;
        Vector3 movByCam = Quaternion.Euler(0f, camDirection, 0f) * mov;

        if (mov != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movByCam);
            controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, targetRotation, controller.sdRotate * Time.deltaTime);
        }


        if (!controller.poisoned)
        {
            controller.rigid.linearVelocity = movByCam * controller.speed * Time.deltaTime;
        }
        else { controller.rigid.linearVelocity = movByCam * controller.speedCorrupted * Time.deltaTime; }
    }
}
