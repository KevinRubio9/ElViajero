using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PatrolStateCogollo : BaseStateCogollo

{
    public PatrolStateCogollo(EnemyShooterLogic controllerParameter) : base(controllerParameter) { }



    public override void EnterState()
    {
        controller.anim.CrossFade("Walk", 0.1f);
    }
    public override void UpdateState()
    {
        Debug.Log("Cogollo esta en estado patrullaje");
        controller.agent.angularSpeed = 120f;
        controller.agent.updateRotation = true;
        controller.agent.stoppingDistance = 0;
        float distanceTarget = Vector3.Distance(controller.agent.transform.position, controller.pointsMov[controller.currentTargert].position);

        if (distanceTarget <= controller.maxDistance)
        {
            controller.currentTargert++;
            if (controller.currentTargert >= controller.pointsMov.Count)
            { controller.currentTargert = 0; }
        }
        controller.agent.SetDestination(controller.pointsMov[controller.currentTargert].position);

        if (controller.playerDetected)
        {

            ExitState(controller.shoot);
        }
    }
    public override void ExitState(BaseStateCogollo newState)
    {
        controller.ChangeState(newState);
    }


}
