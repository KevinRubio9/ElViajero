using System;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class RunState : BaseState
{
    public RunState(PlayerController controllerParameter) :base (controllerParameter) { }

    public override void EnterState()
    {
        controller.anim.CrossFade("Run",0.1f);
    }

    public override void UpdateState()
    {
        Debug.Log("Esta en estado Run");


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

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            ExitState(controller.jump);
        }

        if (Input.GetButtonDown("Fire3") && controller.canDash)
        {
            ExitState(controller.dash);
        }

        if (controller.movHori == 0 && controller.movVert == 0)
        {
            ExitState(controller.idle);
        }

    }

    public override void ExitState(BaseState newState)
    {
        controller.ChangeState(newState);

    }
}
