using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
public class PatrolState : StatesBase
{
    public PatrolState(EnemyMoveController parameters) : base(parameters) { }
    public override void EnterState()
    {
        //controller.anim.CrossFade("Walk", 0.1f);
        controller.agent.speed = controller.patrolSpeed;
        

        if (controller.patrolPoints.Count > 0)
        {
            controller.agent.SetDestination(controller.patrolPoints[controller.currentPoint].position);
        }
    }
    public override void UpdateState()
    {
        controller.currDistance = Vector3.Distance(controller.transform.position, controller.targetAgent.position);
        
        if (controller.currDistance <= controller.actionDistance)
        {
            Debug.Log("Player serca cambiando a chase");
            ExitState(controller.Chase);
        }
        else
        {
            if (controller.patrolPoints.Count == 0) return;

            if (!controller.agent.pathPending && controller.agent.remainingDistance < 0.5f)
            {
                if (controller.waitCounter <= 0f)
                {
                    controller.currentPoint = (controller.currentPoint + 1) % controller.patrolPoints.Count;
                    controller.agent.SetDestination(controller.patrolPoints[controller.currentPoint].position);
                    controller.waitCounter = controller.waitTime;
                }
                else
                {
                    controller.waitCounter -= Time.deltaTime;
                }
            }
        }



    }
    public override void ExitState(StatesBase newState)
    {
        controller.ChangeStatus(newState);
     
    }
}
