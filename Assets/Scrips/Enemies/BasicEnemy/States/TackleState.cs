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

        if (controller.currDistance < controller.actionDistance * 0.2f)
        {
            PlayerController player = controller.targetAgent.GetComponent<PlayerController>();
            LifeController life = controller.targetAgent.GetComponent<LifeController>();

            if (player != null)
            {
                player.Tackle(controller.transform, controller.tackleSpeed, 0.3f);
                controller.lastTackleTime = Time.time;
            }

            if (life != null)
            {
                life.TakeDamage(1);
            }
        }

        if (controller.currDistance > controller.actionDistance * 2f)
        {
            ExitState(controller.patrol);
        }
        else if (controller.currDistance <= controller.actionDistance)
        {
            ExitState(controller.Chase);
        }
    }
       
    public override void ExitState(StatesBase newState)
    {
        controller.ChangeStatus(newState);
        

    }


}
