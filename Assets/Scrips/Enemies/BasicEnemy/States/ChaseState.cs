using UnityEngine;

public class ChaseState : StatesBase
{
    public ChaseState(EnemyMoveController parameters) : base(parameters) { }
    public override void EnterState()
    {
        controller.anim.CrossFade("Walk", 0.1f);
        
    }
    public override void UpdateState()
    {

        Debug.Log("Hongo esta en estado seguir");
        if (controller.targetAgent == null) return;

        controller.currDistance = Vector3.Distance(controller.transform.position, controller.targetAgent.position);

        controller.agent.SetDestination(controller.targetAgent.position);

        if (controller.currDistance <= controller.actionDistance * 0.7f)
        { 
          
            ExitState(controller.tackle);
        }
        if (controller.currDistance > controller.actionDistance * 2f)
        {
           
            ExitState(controller.patrol);
        }
        
    }
    public override void ExitState(StatesBase newState)
    {
        controller.ChangeStatus(newState);
       
    }


}


