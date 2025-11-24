using UnityEngine;

public class ChaseState : StatesBase
{
    public ChaseState(EnemyMoveController parameters) : base(parameters) { }
    public override void EnterState()
    {
        controller.agent.isStopped = false;
    }
    public override void UpdateState()
    {
        Debug.Log("Hongo esta en estado seguir");
        if (controller.targetAgent == null) return;

        controller.currDistance = Vector3.Distance(controller.transform.position, controller.targetAgent.position);

        controller.agent.SetDestination(controller.targetAgent.position);

        if (controller.currDistance <= controller.actionDistance * 0.7f)
        {

            controller.ChangeStatus(controller.tackle);
        }
        if (controller.currDistance > controller.actionDistance * 2f)
        {

            controller.ChangeStatus(controller.patrol);
        }
        
    }
    public override void ExitState(StatesBase newState)
    {
        controller.agent.isStopped = true;
      
       
    }


}


