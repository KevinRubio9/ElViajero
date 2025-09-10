using UnityEngine;

public class TackleState : StatesBase
{
    public TackleState(EnemyMoveController parameters) : base(parameters) { }
    public override void EnterState()
    {
        //controller.anim.CrossFade("Tackle", 0.1f);

    }
    public override void UpdateState()
    {
        if (controller.targetAgent == null) return;

        controller.currDistance = Vector3.Distance(controller.transform.position, controller.targetAgent.position);

        if (controller.currDistance <= controller.actionDistance * 0.7f)
        {
            
        }
    }
    public override void ExitState(StatesBase newState)
    {
        controller.ChangeStatus(newState);

    }


}
